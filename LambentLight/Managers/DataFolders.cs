using NLog;
using SharpCompress.Archives;
using SharpCompress.Archives.Rar;
using SharpCompress.Archives.SevenZip;
using SharpCompress.Archives.Zip;
using SharpCompress.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace LambentLight.Managers
{
    /// <summary>
    /// A class that represents a folder with FiveM server data.
    /// </summary>
    public class DataFolder
    {
        /// <summary>
        /// The logger for our current class.
        /// </summary>
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();
        /// <summary>
        /// The name of the folder.
        /// </summary>
        public string Name { get; private set; }
        /// <summary>
        /// The location of the server data folder
        /// </summary>
        public string Location => Path.Combine(Properties.Settings.Default.FolderData, Name);
        /// <summary>
        /// If the data folder exists.
        /// </summary>
        public bool Exists => Directory.Exists(Location);
        /// <summary>
        /// If the folder has a FiveM server configuration file.
        /// </summary>
        public bool HasConfiguration => File.Exists(Path.Combine(Location, "server.cfg"));
        /// <summary>
        /// The absolute path of the data folder.
        /// </summary>
        public string Absolute => Path.GetFullPath(Location);
        /// <summary>
        /// The location of the resources folder.
        /// </summary>
        public string Resources => Path.Combine(Absolute, "resources");
        /// <summary>
        /// The server configuration for the data folder.
        /// </summary>
        public string Configuration
        {
            get
            {
                // Log that we are loading the server configuration
                Logger.Info("The configuration of {0} has been loaded", Name);
                // If there is a server configuration file
                if (HasConfiguration)
                {
                    return string.Join(Environment.NewLine, File.ReadAllLines(Path.Combine(Absolute, "server.cfg")));
                }
                // Otherwise, return a generic string
                return "# This server data folder does not has a configuration file";
            }
            set
            {
                // Write the string to the file
                File.WriteAllText(Path.Combine(Absolute, "server.cfg"), value);
                // Log that we just saved the configuration
                Logger.Info("The configuration of {0} has been saved", Name);
            }
        }

        /// <summary>
        /// Creates a new instance of the data folder.
        /// </summary>
        /// <param name="name">The name of the folder inside of Data.</param>
        public DataFolder(string name)
        {
            Name = name;
        }

        /// <summary>
        /// Creates a secure string via RNGCryptoServiceProvider.
        /// </summary>
        /// <param name="Length">The desired lenght of the string.</param>
        /// <returns>The secure string with the specified length.</returns>
        private static string GenerateSecureString(int Length)
        {
            // Create a new instance of RNGCryptoServiceProvider
            RNGCryptoServiceProvider RNG = new RNGCryptoServiceProvider();
            // Create a place to store the output
            byte[] Output = new byte[Length];
            // Create the random string as bytes
            RNG.GetBytes(Output);
            // And then, return that byte array as a string
            return Convert.ToBase64String(Output);
        }

        /// <summary>
        /// Generates a new configuration for the current data folder.
        /// </summary>
        /// <returns>The new configuration as a string.</returns>
        public string GenerateConfig()
        {
            // Get the base configuration
            string BaseConfig = Encoding.UTF8.GetString(Properties.Resources.server_cfg);
            // Generate the new configuration
            string NewConfig = string.Format(BaseConfig, GenerateSecureString(32));
            // Set the configuration
            Configuration = NewConfig;
            // Finally, return the new configuration
            return NewConfig;
        }

        /// <summary>
        /// Removes the existing versions of a resource.
        /// </summary>
        /// <param name="resource">The resource to uninstall.</param>
        public void Remove(Resource resource)
        {
            // If the resources folder exists
            if (Directory.Exists(Resources))
            {
                // Get all of the folders that match the resource folder name
                foreach (string Dir in Directory.EnumerateDirectories(Resources, resource.Folder, SearchOption.AllDirectories))
                {
                    // Notify the user
                    Logger.Warn("Removing existing version of {0} at '{1}'", resource.Name, Dir);
                    // And remove the folder
                    Directory.Delete(Dir, true);
                }
            }
        }

        /// <summary>
        /// Installs the specified resource and version on the data folder.
        /// </summary>
        /// <param name="resource">The resource information.</param>
        /// <param name="version">The version to install.</param>
        /// <param name="installRequirements">If the resource requirements should be installed.</param>
        /// <returns>true if the installation succeded, false otherwise.</returns>
        public async Task<bool> InstallResource(Resource resource, Version version, bool installRequirements = true)
        {
            // If the temporary folder does not exists
            if (!Directory.Exists(Properties.Settings.Default.FolderTemp))
            {
                // Create it
                Directory.CreateDirectory(Properties.Settings.Default.FolderTemp);
            }

            // If the resource has requirements and it was requested to install them
            if (resource.Requires != null && installRequirements)
            {
                // Update the list of resources just in case
                ResourceManager.Refresh();

                // Iterate over the requirements
                foreach (string Requirement in resource.Requires)
                {
                    // Try to find the correct resource
                    Resource Found = ResourceManager.Resources.Where(res => res.Name == Requirement).FirstOrDefault();

                    // If there is a resource found
                    if (Found != null)
                    {
                        // If the resource is already installed
                        if (resource.IsInstalledIn(this))
                        {
                            // Notify that it is
                            Logger.Info("The resource {0} required by {1} is already installed, skipping...", Found.Name, resource.Name);
                        }
                        // Otherwise
                        else
                        {
                            // Notify the user
                            Logger.Info("Installing requirement {0} by {1}", resource.Name, Found.Name);
                            // Install the resource
                            await InstallResource(Found, Found.Versions[0], false);
                        }
                    }
                    // Otherwise
                    else
                    {
                        // Notify the user with an error
                        Logger.Error("The resource {0} requires {1} but it was not found", resource.Name, Requirement);
                    }
                }
            }

            // Format a path for the output file
            string ExtractionPath = Path.Combine(Properties.Settings.Default.FolderTemp, $"{resource.Name}-{version.ReadableVersion}");
            string TempFilePath = ExtractionPath + version.Extension;
            // Notify that we are starting the download
            Logger.Info("Starting the download of {0} {1}", resource.Name, version.ReadableVersion);

            // If the temp file exists
            if (File.Exists(TempFilePath))
            {
                // Yeet it
                File.Delete(TempFilePath);
            }

            // Let's try to download the file
            try
            {
                // Use a context manager
                using (WebClient Client = new WebClient())
                {
                    // Set the event to refresh the progress bar
                    Client.DownloadProgressChanged += Program.OnDownloadProgressChanged;

                    // Start downloading the file
                    await Client.DownloadFileTaskAsync(version.Download, TempFilePath);
                }
            }
            catch (WebException e)
            {
                // Log the error
                Logger.Error("Error while downloading {0}: {1}", version.Download, e.Message);
                // Reset the progress bar value
                Program.Form.MainProgressBar.Value = 0;
                // And return
                return false;
            }

            // If the resources folder does not exists
            if (!Directory.Exists(Resources))
            {
                // Create it
                Directory.CreateDirectory(Resources);
            }

            // Remove the existing versions of the resource
            Remove(resource);

            // If the output directory exists
            if (Directory.Exists(ExtractionPath))
            {
                // Remove it
                Directory.Delete(ExtractionPath, true);
            }

            // Create the temporary extraction directory
            Directory.CreateDirectory(ExtractionPath);

            // Notify that we are starting the extraction of the file
            Logger.Info("Extracting {0} {1} to '{2}'", resource.Name, version.ReadableVersion, ExtractionPath);
            // Try to extract the file
            try
            {
                Compression.Extract(TempFilePath, ExtractionPath, version.Compression);
            }
            // If we fail, log the error message and return
            catch (InvalidOperationException e)
            {
                Logger.Error(e.Message);
                return false;
            }

            // Remove the temporary compressed file
            File.Delete(TempFilePath);

            // Notify that we have finished with the extraction and we have started moving stuff
            Logger.Info("Moving the folder of {0} {1} to resources...", resource.Name, version.ReadableVersion);

            // Select the correct path inside of the extraction folder
            // In order: Version Path, Resource Path or an Empty String
            string CompressedPath = version.Path ?? resource.Path ?? "";
            // Create the path for the folder that we need to move
            string ChoosenFolder = Path.Combine(ExtractionPath, CompressedPath);
            // Create the destination directory (aka the path inside of the resources directory)
            string DestinationFolder = Path.Combine(Resources, resource.Folder);

            // Move the folder and notify the user
            Directory.Move(ChoosenFolder, DestinationFolder);
            Logger.Info("Success! {0} {1} has been installed", resource.Name, version.ReadableVersion);

            // Finally, reset the progress bar value and return
            Program.Form.MainProgressBar.Value = 0;
            return true;
        }

        /// <summary>
        /// Gets the directory name.
        /// </summary>
        /// <returns>The name of the directory.</returns>
        public override string ToString() => Name;

        /// <summary>
        /// Checks if the compared object has the same name as the current one.
        /// </summary>
        public override bool Equals(object obj) => obj is DataFolder && Name == ((DataFolder)obj).Name;
    }

    /// <summary>
    /// Managers for the folders that contain our data.
    /// </summary>
    public static class DataFolderManager
    {
        /// <summary>
        /// The logger for our current class.
        /// </summary>
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();
        /// <summary>
        /// Our current set of data folders.
        /// </summary>
        public static List<DataFolder> Folders = new List<DataFolder>();

        /// <summary>
        /// Refreshes the builds with data.
        /// </summary>
        public static void Refresh()
        {
            // Reset the list of data folders
            Folders = new List<DataFolder>();

            // If the data folder does not exists
            if (!Directory.Exists(Properties.Settings.Default.FolderData))
            {
                // Create it
                Directory.CreateDirectory(Properties.Settings.Default.FolderData);
            }

            // Iterate over the folders on our Data folder
            foreach (string Dir in Directory.GetDirectories(Properties.Settings.Default.FolderData))
            {
                // And add our data folder
                Folders.Add(new DataFolder(Path.GetFileName(Dir)));
            }

            // Log what we have just done
            Logger.Debug("The list of server data folders has been updated");
        }

        /// <summary>
        /// Creates a new server data folder.
        /// </summary>
        /// <param name="name">The name of the folder.</param>
        public static async Task<DataFolder> Create(string name)
        {
            // Create the Data folder if it does not exists
            if (Directory.Exists(Properties.Settings.Default.FolderData))
            {
                Directory.CreateDirectory(Properties.Settings.Default.FolderData);
            }

            // If the text is whitespaces or null, notify the user and return
            if (string.IsNullOrWhiteSpace(name))
            {
                Logger.Warn("The path that you have entered is null or consists only of whitespaces");
                return null;
            }

            // Generate the destination path
            string NewPath = Path.Combine(Properties.Settings.Default.FolderData, name);

            // If the folder specified already exists, warn the user and return
            if (Directory.Exists(NewPath))
            {
                Logger.Warn("The specified folder name already exists");
                return null;
            }

            // If the user wants to download the scripts
            if (Properties.Settings.Default.DownloadScripts)
            {
                // Notify the user that we are downloading the repository
                Logger.Info("Downloading Default Scripts for the Data Folder '{0}', please wait...", name);

                // Create the path for the temporary zip file
                string ZipPath = Path.Combine(Properties.Settings.Default.FolderTemp, "cfx-server-data.zip");

                // If the temporary folder does not exists
                if (!Directory.Exists(Properties.Settings.Default.FolderTemp))
                {
                    // Create it
                    Directory.CreateDirectory(Properties.Settings.Default.FolderTemp);
                }

                // Use a context manager
                using (WebClient Client = new WebClient())
                {
                    // Set the event to refresh the progress bar
                    Client.DownloadProgressChanged += Program.OnDownloadProgressChanged;

                    // Start downloading the file
                    await Client.DownloadFileTaskAsync("https://github.com/citizenfx/cfx-server-data/archive/master.zip", ZipPath);

                    // Wait until the file has been downloaded
                    while (Client.IsBusy)
                    {
                        await Task.Delay(0);
                    }
                }

                // After the zip file has been downloaded, extract it
                Compression.ExtractZip(ZipPath, Properties.Settings.Default.FolderTemp);
                // Then, rename it to the name specified by the user
                Directory.Move(Path.Combine(Properties.Settings.Default.FolderTemp, "cfx-server-data-master"), NewPath);
                // Delete the temporary file
                File.Delete(ZipPath);
                // And finally reset the progress bar value
                Program.Form.MainProgressBar.Value = 0;
            }
            else
            {
                // Create the directory and notify the user
                Directory.CreateDirectory(NewPath);
            }

            // Create the object for the new data folder
            DataFolder NewFolder = new DataFolder(name);

            // Notify the user that we have finished with the creation of the folder
            Logger.Info("The Data Folder '{0}' has been created", name);

            // If the user wants to generate the configuration
            if (Properties.Settings.Default.CreateConfig)
            {
                // Generate the new configuration for the folder
                NewFolder.GenerateConfig();
            }

            // Finally, return the data object
            return NewFolder;
        }
    }
}
