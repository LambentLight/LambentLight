using System.IO;

namespace LambentLight.DataFolders
{
    /// <summary>
    /// Class for managing a specific Data Folder.
    /// </summary>
    public class DataFolder
    {
        #region Properties

        /// <summary>
        /// The name of the folder.
        /// </summary>
        public string Name { get; private set; }
        /// <summary>
        /// The absolute location of the folder.
        /// </summary>
        public string Location { get; private set; }

        #endregion

        #region Constructor

        public DataFolder(string folder)
        {
            // If the folder specified does not exists, raise an exception
            if (!Directory.Exists(folder))
            {
                throw new DirectoryNotFoundException("The directory of the Data Folder was not found");
            }

            // Otherwise, save the name and absolute location
            Name = Path.GetFileName(folder);
            Location = Path.GetFullPath(folder);
        }

        #endregion
    }
}
