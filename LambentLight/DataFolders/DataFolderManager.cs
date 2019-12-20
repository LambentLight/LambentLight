using NLog;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace LambentLight.DataFolders
{
    /// <summary>
    /// Managers for the folders that contain our data.
    /// </summary>
    public static class DataFolderManager
    {
        #region Private Fields

        /// <summary>
        /// The logger for our current class.
        /// </summary>
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        #endregion

        #region Public Properties

        /// <summary>
        /// Our current set of data folders.
        /// </summary>
        public static List<DataFolder> Folders { get; private set; } = new List<DataFolder>();

        #endregion

        #region Public Functions

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
        public static async Task<DataFolder> Create(string name, string rconPassword = null, bool allowScriptHook = false)
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
            if (Program.Config.Creator.DownloadScripts)
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
            if (Program.Config.Creator.CreateConfig)
            {
                // Generate the new configuration for the folder
                NewFolder.GenerateConfig(rconPassword, allowScriptHook);
            }

            // Finally, return the data object
            return NewFolder;
        }

        #endregion
    }
}
