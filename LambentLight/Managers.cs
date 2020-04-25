using LambentLight.Builds;
using LambentLight.DataFolders;

namespace LambentLight
{
    /// <summary>
    /// Class to access all of the content managers.
    /// </summary>
    public static class Managers
    {
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
