using LibGit2Sharp;
using Serilog;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace LambentLight.DataFolders
{
    /// <summary>
    /// Manager of Folders that contain server data.
    /// </summary>
    public class DataFolderManager : BaseManager
    {
        #region Fields

        /// <summary>
        /// The GIT URL for the Server Data Repository.
        /// </summary>
        private const string RepoURL = "https://github.com/LambentLight/ServerData.git";
        /// <summary>
        /// The location of the repository folder.
        /// </summary>
        public readonly string RepoFolder = Path.Combine("repo");

        #endregion

        #region Properties

        /// <summary>
        /// The list of data folders available to be used.
        /// </summary>
        public List<DataFolder> Folders { get; private set; } = new List<DataFolder>();
        /// <summary>
        /// If the Server Data Repository exists.
        /// </summary>
        public bool RepoExists => Directory.Exists(RepoFolder);

        #endregion

        #region Public Functions

        /// <summary>
        /// Initializes the Data Folder Manager.
        /// </summary>
        public override async Task Initialize()
        {
            Log.Information($"Initializing {GetType().Name}");
            await Update();
            ReadyToWork = true;
        }
        /// <summary>
        /// Generates a new list of server Data Folders.
        /// </summary>
        public override async Task Update()
        {
            // If the "data" folder does not exists, just return
            if (!Directory.Exists("data"))
            {
                Log.Information("Directory with Data Folders is missing, skipped");
                return;
            }

            // If it does, create a new temporary list
            List<DataFolder> temp = new List<DataFolder>();

            // Iterate over the directories and add them
            foreach (string folder in Directory.GetDirectories("data"))
            {
                temp.Add(new DataFolder(folder));
            }

            // Finally, set the temp list as the real one
            Folders = temp;
            Log.Information($"Found {temp.Count} Data Folders");
        }
        /// <summary>
        /// Downloads the Server Data repository.
        /// </summary>
        public void DownloadRepo()
        {
            // If the repository already exists, delete it
            if (RepoExists)
            {
                Directory.Delete(RepoFolder);
            }
            // Clone the repo with libgit
            Repository.Clone(RepoURL, RepoFolder);
        }

        #endregion
    }
}
