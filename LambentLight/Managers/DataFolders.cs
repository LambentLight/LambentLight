using LambentLight.Properties;
using NLog;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LambentLight.Managers
{
    /// <summary>
    /// Class that handles a
    /// </summary>
    public class InstalledResource : IDisposable
    {
        /// <summary>
        /// The name of the resource.
        /// </summary>
        public string Name => Path.GetFileNameWithoutExtension(Location);
        /// <summary>
        /// Where the resource is located.
        /// </summary>
        public string Location { get; }
        /// <summary>
        /// The Data Folder where this resource is located.
        /// </summary>
        public DataFolder Source { get; }
        /// <summary>
        /// Checks if a resource is present on the specified folder.
        /// </summary>
        public bool IsPresent => Directory.Exists(Location);

        public InstalledResource(DataFolder source, string location)
        {
            Source = source;
            Location = location;
        }

        /// <summary>
        /// Removes the resource if is present.
        /// </summary>
        public void Dispose()
        {
            // If the resource exists and is present
            if (IsPresent)
            {
                // Remove it
                Directory.Delete(Location, true);
            }
        }

        public override string ToString()
        {
            return Name;
        }
    }

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
        public string Location => Path.Combine(Locations.Data, Name);
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
        /// 
        /// </summary>
        public List<InstalledResource> InstalledResources
        {
            get
            {
                // Create a temp list of resources
                List<InstalledResource> TempResources = new List<InstalledResource>();

                // Iterate over the directories in the resources folder
                foreach (string Folder in Directory.EnumerateDirectories(Resources))
                {
                    // Get the literal directory name
                    string Name = Path.GetFileNameWithoutExtension(Folder);

                    // If the folder name does not starts with [ and ]
                    if (!Name.StartsWith("[") && !Name.EndsWith("]"))
                    {
                        // Add it
                        TempResources.Add(new InstalledResource(this, Folder));
                    }
                }

                // Finally, return the installed resources
                return TempResources;
            }
        }
        /// <summary>
        /// The server configuration for the data folder.
        /// </summary>
        public string Configuration
        {
            get
            {
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
            string BaseConfig = Encoding.UTF8.GetString(Properties.Resources.ConfigurationTemplate);
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
        public async Task InstallResource(Resource resource, Version version, bool installRequirements = true)
        {
            // Notify that we are starting the install of there resource
            Logger.Info("Installing resource {0} {1}", resource.Name, version.ReadableVersion);

            // If the temporary folder does not exists
            Locations.EnsureTempFolder();

            // Format a path for the output file
            string ExtractionPath = Path.Combine(Locations.Temp, $"{resource.Folder}-{version.ReadableVersion}");
            string TempFilePath = ExtractionPath + Path.GetExtension(version.Download);

            // If the temp file exists
            if (File.Exists(TempFilePath))
            {
                // Yeet it
                File.Delete(TempFilePath);
            }

            // If the we tried to download the file and we ended up failing, return
            if (!await Downloader.DownloadFile(version.Download, TempFilePath))
            {
                return;
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
            Logger.Info("Extracting {0} {1}...", resource.Name, version.ReadableVersion);
            // Try to extract the file
            try
            {
                await Compression.Extract(TempFilePath, ExtractionPath);
            }
            // If we fail, log the error message and return
            catch (InvalidOperationException e)
            {
                Logger.Error(e.Message);
                return;
            }

            // Remove the temporary compressed file
            File.Delete(TempFilePath);

            // Select the correct path inside of the extraction folder
            // In order: Version Path, Resource Path or an Empty String
            string CompressedPath = version.Path ?? resource.Path ?? "";
            // Create the path for the folder that we need to move
            string ChoosenFolder = Path.Combine(ExtractionPath, CompressedPath);
            // Create the destination directory (aka the path inside of the resources directory)
            string DestinationFolder = Path.Combine(Resources, resource.Folder);

            // If the resource has aditional configuration instructions
            if (resource.ConfigInstructions != null)
            {
                // Ask the user if he wants to open the configuration instructions
                DialogResult Result = MessageBox.Show($"The resource {resource.Name} requires aditional configuration\nDo you want to open the configuration instructions in your browser?", "Configuration required", MessageBoxButtons.YesNo);

                // If it does
                if (Result == DialogResult.Yes)
                {
                    // Open it up
                    Process.Start(resource.ConfigInstructions);
                }
            }

            // Try to move the folder with the resource
            try
            {
                Directory.Move(ChoosenFolder, DestinationFolder);
            }
            // If the directory was not found, notify the user and return
            catch (DirectoryNotFoundException)
            {
                Logger.Error("Unable to find '{0}' inside of the file", CompressedPath);
            }

            // And delete the temporary folder if it exists
            if (Directory.Exists(ExtractionPath))
            {
                Directory.Delete(ExtractionPath, true);
            }

            // Finally, notify that we have finished
            Logger.Info("Done! {0} {1} has been installed", resource.Name, version.ReadableVersion);
        }

        /// <summary>
        /// Gets the directory name.
        /// </summary>
        /// <returns>The name of the directory.</returns>
        public override string ToString() => Name;
        /// <summary>
        /// Gets the Hash of the Build Identifier.
        /// </summary>
        public override int GetHashCode() => Name.GetHashCode();
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
            Locations.EnsureDataFolder();

            // Iterate over the folders on our Data folder
            foreach (string Dir in Directory.GetDirectories(Locations.Data))
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
            Locations.EnsureDataFolder();

            // If the text is whitespaces or null, notify the user and return
            if (string.IsNullOrWhiteSpace(name))
            {
                Logger.Warn("The path that you have entered is empty or consists only of whitespaces");
                return null;
            }

            // Generate the destination path
            string NewPath = Path.Combine(Locations.Data, name);

            // If the folder specified already exists, warn the user and return
            if (Directory.Exists(NewPath))
            {
                Logger.Warn("The specified folder name already exists");
                return null;
            }

            // If the user wants to download the scripts
            if (Settings.Default.DownloadScripts)
            {
                // Notify the user that we are downloading the repository
                Logger.Info("Downloading Default Scripts for the Data Folder '{0}', please wait...", name);

                // Create the path for the temporary zip file
                string ZipPath = Path.Combine(Locations.Temp, "ServerData.zip");

                // If the temporary folder does not exists
                Locations.EnsureTempFolder();

                // If we didn't managed to download the file, just return
                if (!await Downloader.DownloadFile("https://github.com/LambentLight/ServerData/archive/master.zip", ZipPath))
                {
                    return null;
                }

                // After the zip file has been downloaded, extract it
                await Compression.Extract(ZipPath, Locations.Temp);
                // Then, rename it to the name specified by the user
                Directory.Move(Path.Combine(Locations.Temp, "ServerData-master"), NewPath);
                // Delete the temporary file
                File.Delete(ZipPath);
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
            if (Settings.Default.CreateConfig)
            {
                // Generate the new configuration for the folder
                NewFolder.GenerateConfig();
            }

            // Finally, return the data object
            return NewFolder;
        }
    }
}
