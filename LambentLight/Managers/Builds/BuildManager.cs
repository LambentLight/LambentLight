using NLog;
using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace LambentLight.Managers.Builds
{
    /// <summary>
    /// Class that manages the downloads and updates of builds.
    /// </summary>
    public static class BuildManager
    {
        #region Private Fields

        /// <summary>
        /// The logger for our current class.
        /// </summary>
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();
        /// <summary>
        /// The download URL for the current operating system.
        /// </summary>
        private static readonly string DownloadURL = $"{Program.Config.Builds}/builds.json";

        #endregion

        #region Public Properties

        /// <summary>
        /// The updated list of builds.
        /// </summary>
        public static List<Build> Builds { get; private set; } = new List<Build>();

        #endregion

        #region Public Functions

        /// <summary>
        /// Refreshes the list of builds.
        /// </summary>
        public static void Refresh()
        {
            // Get all of the builds available on the CFX Servers
            List<Build> builds = Downloader.DownloadJSON<List<Build>>(DownloadURL, new BuildConverter()) ?? new List<Build>();
            // Ensure that the builds folder exists
            Locations.EnsureBuildsFolder();

            // Iterate over the existing build folders
            foreach (string build in Directory.EnumerateDirectories(Locations.Builds))
            {
                // Create a new object for that folder
                Build newBuild = new Build(Path.GetFileName(build));

                // If the build is not already on the list, add it
                if (!builds.Contains(newBuild))
                {
                    builds.Add(newBuild);
                }
            }

            // Set the new builds
            Builds = builds;
            // Log what we have just done
            Logger.Debug("The list of builds has been updated");
        }
        /// <summary>
        /// Installs the specified build from a compressed file.
        /// </summary>
        /// <param name="file">The build in a compressed file.</param>
        /// <param name="name">The name or hash of the build.</param>
        public static async Task Install(string file, string name = null)
        {
            // If the name is null or whitespaces
            if (string.IsNullOrWhiteSpace(name))
            {
                // Open the file
                using (FileStream stream = File.OpenRead(file))
                using (SHA1Managed sha = new SHA1Managed())
                {
                    // Calculate the checksum of it
                    byte[] checksum = sha.ComputeHash(stream);
                    // And convert it to a string so we can use it
                    string hash = BitConverter.ToString(checksum).Replace("-", "").ToLowerInvariant();
                    // Finally, format the checksum so we 
                    name = $"custom-{hash}";
                }
            }

            // Log that we have started the installation of this build
            Logger.Info("Installing build {0}...", name);

            // Create the path of the folder
            string path = Path.Combine(Locations.Builds, name);

            // If the build folder exists, delete it
            if (Directory.Exists(path))
            {
                Directory.Delete(path, true);
            }
            // And create a new one
            Directory.CreateDirectory(path);

            // Finally, extract the contents of the file
            await Compression.Extract(file, path);

            // Log that we have finished the extraction
            Logger.Info("CFX Build {0} has been installed", name);
        }

        #endregion
    }
}
