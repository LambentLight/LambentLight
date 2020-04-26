using LambentLight.Builds;
using LambentLight.DataFolders;
using LambentLight.Runtime;

namespace LambentLight
{
    /// <summary>
    /// Class to access all of the content managers.
    /// </summary>
    public static class Managers
    {
        /// <summary>
        /// Manager for the server process.
        /// </summary>
        public static RuntimeManager RuntimeManager = new RuntimeManager();
        /// <summary>
        /// Manager for the CFX Builds.
        /// </summary>
        public static BuildManager BuildManager = new BuildManager();
        /// <summary>
        /// Manager for Data Folders.
        /// </summary>
        public static DataFolderManager FolderManager = new DataFolderManager();
    }
}
