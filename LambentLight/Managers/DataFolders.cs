using NLog;
using SharpCompress.Archives;
using SharpCompress.Archives.Rar;
using SharpCompress.Archives.SevenZip;
using SharpCompress.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
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
        /// The web client for REST calls.
        /// </summary>
        private static WebClient Client = new WebClient();
        /// <summary>
        /// The name of the folder.
        /// </summary>
        public string Name { get; private set; }
        /// <summary>
        /// The location of the server data folder
        /// </summary>
        public string Location => Path.Combine("Data", Name);
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
        /// Extraction options to use with SharpCompress.
        /// </summary>
        private readonly ExtractionOptions ExtractOpts = new ExtractionOptions() { ExtractFullPath = true };

        /// <summary>
        /// Creates a new instance of the data folder.
        /// </summary>
        /// <param name="name">The name of the folder inside of Data.</param>
        public DataFolder(string name)
        {
            Name = name;
        }

        /// <summary>
        /// Installs the specified resource and version on the data folder.
        /// </summary>
        /// <param name="resource">The resource information.</param>
        /// <param name="version">The version to install.</param>
        /// <returns>true if the installation succeded, false otherwise.</returns>
        public async Task<bool> InstallResource(Resource resource, Version version)
        {
            // If the temporary folder does not exists
            if (!Directory.Exists("Resources"))
            {
                // Create it
                Directory.CreateDirectory("Resources");
            }

            // Format a path for the output file
            string ExtractionPath = Path.Combine("Resources", $"{resource.Name}-{version.ReadableVersion}");
            string TempFilePath = ExtractionPath + version.GetExtension();
            // Notify that we are starting the download
            Logger.Info("Starting the download of {0} from '{1}' to '{2}'", resource.Name, version.Download, TempFilePath);

            // If the temp file exists
            if (File.Exists(TempFilePath))
            {
                // Yeet it
                File.Delete(TempFilePath);
            }

            // Let's try to download the file
            try
            {
                // Start downloading the file
                await Client.DownloadFileTaskAsync(version.Download, TempFilePath);
            }
            catch (WebException e)
            {
                Logger.Error("Error while downloading {0}: {1}", version.Download, e.Message);
                return false;
            }

            // Get all of the folders that match the resource folder name
            foreach (string Dir in Directory.EnumerateDirectories(Path.Combine(Absolute, "resources"), resource.Folder, SearchOption.AllDirectories))
            {
                // Notify the user
                Logger.Warn("Removing existing version of {0}: '{1}'", resource.Folder, Dir);
                // And remove the folder
                Directory.Delete(Dir, true);
            }

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
            // Extract the file by using the correct extraction format
            switch (version.Compression)
            {
                case CompressionType.Zip:
                    await Task.Run(() => ZipFile.ExtractToDirectory(TempFilePath, ExtractionPath));
                    break;
                case CompressionType.SevenZip:
                    using (SevenZipArchive SevenZip = SevenZipArchive.Open(ExtractionPath))
                    {
                        foreach (SevenZipArchiveEntry Entry in SevenZip.Entries.Where(X => !X.IsDirectory))
                        {
                            Entry.WriteToDirectory(ExtractionPath, ExtractOpts);
                        }
                    }
                    break;
                case CompressionType.Rar:
                    using (RarArchive Rar = RarArchive.Open(ExtractionPath))
                    {
                        foreach (RarArchiveEntry Entry in Rar.Entries.Where(X => !X.IsDirectory))
                        {
                            Entry.WriteToDirectory(ExtractionPath, ExtractOpts);
                        }
                    }
                    break;
                default:
                    Logger.Error("The file '{0}' has an unsuported compression type ({1} - {2})", version.Download, version.Compression, (int)version.Compression);
                    return false;
            }

            // Notify that we have finished with the extraction and we have started moving stuff
            Logger.Info("Moving the folder of {0} {1} to resources...", resource.Name, version.ReadableVersion);

            // Select the correct path inside of the extraction folder
            // In order: Version Path, Resource Path or an Empty String
            string CompressedPath = version.Path ?? resource.Path ?? "";
            // Create the path for the folder that we need to move
            string ChoosenFolder = Path.Combine(ExtractionPath, CompressedPath);
            // Create the destination directory (aka the path inside of the resources directory)
            string DestinationFolder = Path.Combine(Absolute, "resources", resource.Folder);

            // Finally, move the folder and notify the user
            Directory.Move(ChoosenFolder, DestinationFolder);
            Logger.Info("Success! {0} {1} has been installed", resource.Name, version.ReadableVersion);
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
        /// The web client for REST calls.
        /// </summary>
        private static WebClient Client = new WebClient();
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
            if (!Directory.Exists("Data"))
            {
                // Create it
                Directory.CreateDirectory("Data");
            }

            // Iterate over the folders on our Data folder
            foreach (string Dir in Directory.GetDirectories("Data"))
            {
                // And add our data folder
                Folders.Add(new DataFolder(Path.GetFileName(Dir)));
            }

            // Log what we have just done
            Logger.Info("The list of server data folders has been updated");
        }

        /// <summary>
        /// Creates a new server data folder.
        /// </summary>
        /// <param name="name">The name of the folder.</param>
        public static async Task<DataFolder> Create(string name)
        {
            // Create the Data folder if it does not exists
            if (Directory.Exists("Data"))
            {
                Directory.CreateDirectory("Data");
            }

            // If the text is whitespaces or null, notify the user and return
            if (string.IsNullOrWhiteSpace(name))
            {
                Logger.Warn("The path that you have entered is null or consists only of whitespaces");
                return null;
            }

            // Generate the destination path
            string NewPath = Path.Combine("Data", name);

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
                string ZipPath = Path.Combine("Data", "cfx-server-data.zip");
                // Start downloading the file
                await Client.DownloadFileTaskAsync("https://github.com/citizenfx/cfx-server-data/archive/master.zip", ZipPath);

                // Wait until the file has been downloaded
                while (Client.IsBusy)
                {
                    await Task.Delay(0);
                }

                // After the zip file has been downloaded, extract it
                await Task.Run(() => ZipFile.ExtractToDirectory(ZipPath, "Data"));
                // Then, rename it to the name specified by the user
                Directory.Move(Path.Combine("Data", "cfx-server-data-master"), NewPath);
                // Finally, delete the temporary file
                File.Delete(ZipPath);
            }
            else
            {
                // Create the directory and notify the user
                Directory.CreateDirectory(NewPath);
            }

            // If the user wants to generate the configuration
            if (Properties.Settings.Default.CreateConfig)
            {
                // Notify the user that we have finished with the creation of the folder
                Logger.Info("The Data Folder '{0}' has been created", name);

                // Get the string and add a random RCON password to it
                string Config = string.Format(Encoding.UTF8.GetString(Properties.Resources.server_cfg), GenerateSecureString(32));
                File.WriteAllText(Path.Combine(NewPath, "server.cfg"), Config);
            }

            // Finally, return the data object
            return new DataFolder(name);
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
    }
}
