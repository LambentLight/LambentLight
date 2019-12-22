using LambentLight.Config;
using System.IO;
using System.Reflection;

namespace LambentLight
{
    /// <summary>
    /// Class that contains the file and folder locations.
    /// </summary>
    public static class Locations
    {
        /// <summary>
        /// Absolute URL path for the program.
        /// </summary>
        public static readonly string Base = Path.GetDirectoryName(Assembly.GetEntryAssembly().CodeBase).Substring(6);
        /// <summary>
        /// Absolute path of the builds folder.
        /// </summary>
        public static readonly string Builds = Path.Combine(Base, Configuration.FolderBuilds, "windows");
        /// <summary>
        /// Absolute path of the server data folder.
        /// </summary>
        public static readonly string Data = Path.Combine(Base, Configuration.FolderData);
        /// <summary>
        /// Absolute path of the temporary files folder.
        /// </summary>
        public static readonly string Temp = Path.Combine(Base, Configuration.FolderTemp);

        /// <summary>
        /// Ensures that the builds folder is present.
        /// </summary>
        public static void EnsureBuildsFolder() => EnsureFolder(Builds);
        /// <summary>
        /// Ensures that the server data folder is present.
        /// </summary>
        public static void EnsureDataFolder() => EnsureFolder(Data);
        /// <summary>
        /// Ensures that the builds folder is present.
        /// </summary>
        public static void EnsureTempFolder() => EnsureFolder(Temp);

        /// <summary>
        /// Ensures that a folder exists.
        /// </summary>
        private static void EnsureFolder(string folder)
        {
            // If the folder does not exists
            if (!Directory.Exists(folder))
            {
                // Create it
                Directory.CreateDirectory(folder);
            }
        }
    }
}
