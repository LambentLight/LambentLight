using LambentLight.Properties;
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
        public static readonly string Base = Path.GetDirectoryName(Assembly.GetEntryAssembly().CodeBase);
        /// <summary>
        /// Absolute system-aware path for the program.
        /// </summary>
        public static readonly string Absolute = Base.Substring(Checks.IsWindows ? 6 : 5);
        /// <summary>
        /// Absolute path of the builds folder.
        /// </summary>
        public static readonly string BuildsBase = Path.Combine(Absolute, Settings.Default.FolderBuilds);
        /// <summary>
        /// Absolute path of the builds folder for the current operating system (Windows or Linux).
        /// </summary>
        public static readonly string BuildsForOS = Path.Combine(BuildsBase, Checks.IsWindows ? "windows" : "linux");
        /// <summary>
        /// Absolute path of the server data folder.
        /// </summary>
        public static readonly string Data = Path.Combine(Absolute, Settings.Default.FolderData);
        /// <summary>
        /// Absolute path of the temporary files folder.
        /// </summary>
        public static readonly string Temp = Path.Combine(Absolute, Settings.Default.FolderTemp);

        /// <summary>
        /// Ensures that the builds folder is present.
        /// </summary>
        public static void EnsureBuildsFolder()
        {
            EnsureFolder(BuildsBase);
            EnsureFolder(BuildsForOS);
        }
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
