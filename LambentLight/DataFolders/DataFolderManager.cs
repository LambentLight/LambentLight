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
        /// Creates a new Server Data folder.
        /// </summary>
        /// <param name="name">The name of the data folder.</param>
        /// <param name="rconPassword">The RCON password.</param>
        /// <param name="allowScriptHook">If ScriptHookV should be allowed.</param>
        public static async Task<DataFolder> Create(string name, string rconPassword = null, bool allowScriptHook = false)
        {
            // If the text is whitespaces or null, notify the user and return
            if (string.IsNullOrWhiteSpace(name))
            {
                Logger.Warn("The path that you have entered is empty or consists only of whitespaces");
                return null;
            }

            // Create the object for the data folder
            DataFolder folder = new DataFolder(name);

            // If the folder specified already exists, warn the user and return
            if (folder.Exists)
            {
                Logger.Warn("The specified folder name already exists");
                return null;
            }

            // Call recreate to create the folder
            await folder.Recreate();
            // Finally, return the data object
            return folder;
        }

        #endregion
    }
}
