using LambentLight.Properties;
using Newtonsoft.Json;
using NLog;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Security.Cryptography;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LambentLight.Managers
{
    /// <summary>
    /// Class that contains the information of a specific FiveM build.
    /// </summary>
    public class Build
    {
        /// <summary>
        /// The ID of the build. This can be either the folder name or Upstream identifier.
        /// </summary>
        public string ID { get; private set; }
        /// <summary>
        /// If the build is available locally.
        /// </summary>
        public bool IsAvailable => Directory.Exists(Folder);
        /// <summary>
        /// The local folder where the build can be located.
        /// </summary>
        public string Folder => Path.Combine(Locations.BuildsForOS, ID);

        /// <summary>
        /// Creates a Build to use with LambentLight
        /// </summary>
        /// <param name="identifier">The folder name or Upstream identifier.</param>
        public Build(string identifier)
        {
            // Set our identifier
            ID = identifier;
        }

        /// <summary>
        /// Gets the string representation of a build.
        /// </summary>
        public override string ToString() => ID;
        /// <summary>
        /// Gets the Hash of the Build Identifier.
        /// </summary>
        public override int GetHashCode() => ID.GetHashCode();
        /// <summary>
        /// Checks if the compared object has the same ID as the current one.
        /// </summary>
        public override bool Equals(object obj) => obj is Build && ID == ((Build)obj).ID;
    }

    /// <summary>
    /// A JSON converter for FiveM builds.
    /// </summary>
    public class BuildConverter : JsonConverter<Build>
    {
        public override Build ReadJson(JsonReader reader, Type objectType, Build existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            // Return the value from the known color
            return new Build((string)reader.Value);
        }

        public override void WriteJson(JsonWriter writer, Build value, JsonSerializer serializer)
        {
            // We are only going to read, so disable the writing by raising an exception
            throw new NotImplementedException();
        }
    }

    /// <summary>
    /// Class that manages the downloads and updates of builds.
    /// </summary>
    public static class BuildManager
    {
        /// <summary>
        /// The logger for our current class.
        /// </summary>
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();
        /// <summary>
        /// The updated list of builds.
        /// </summary>
        public static List<Build> Builds = new List<Build>();
        /// <summary>
        /// The download URL for the current operating system.
        /// </summary>
        private static readonly string DownloadURL = Checks.IsWindows ? Settings.Default.BuildsWindows : Settings.Default.BuildsLinux;
        /// <summary>
        /// The download URL for a specific operating system.
        /// </summary>
        private static readonly string DownloadBuild = Checks.IsWindows ? "https://runtime.fivem.net/artifacts/fivem/build_server_windows/master/{0}/server.zip" : "https://runtime.fivem.net/artifacts/fivem/build_proot_linux/master/{0}/fx.tar.xz";

        /// <summary>
        /// Refreshes the list of builds.
        /// </summary>
        public static void Refresh()
        {
            // Create a temporary list of builds
            List<Build> NewBuilds = Downloader.DownloadJSON<List<Build>>(DownloadURL, new BuildConverter()) ?? new List<Build>();
            // Ensure that the builds folder is present
            Locations.EnsureBuildsFolder();

            // Iterate over the existing builds
            foreach (string Found in Directory.EnumerateDirectories(Locations.BuildsForOS))
            {
                // Create a new build object
                Build NewBuild = new Build(Path.GetFileName(Found));

                // If the build is not there
                if (!NewBuilds.Contains(NewBuild))
                {
                    // Add the new build
                    NewBuilds.Add(NewBuild);
                }
            }

            // Set the new builds
            Builds = NewBuilds;
            // Log what we have just done
            Logger.Debug("The list of builds has been updated");
        }

        /// <summary>
        /// Downloads the specified build.
        /// </summary>
        /// <param name="build">The build to download.</param>
        public static async Task Download(Build build)
        {
            // If we are running on Linux
            if (Checks.IsLinux)
            {
                // Say that we do not support the automatic download of builds
                DialogResult Result = MessageBox.Show("Sorry, but we can't download builds right now due to a decompression problem.\nDo you want to open the build on your browser so it can be installed manually?", "Impossible to download", MessageBoxButtons.YesNo);
                // If the user wants download the build manually
                if (Result == DialogResult.Yes)
                {
                    // Open it up on the browser
                    Process.Start(string.Format(DownloadBuild, build.ID));
                }
            }

            // Log that we are starting the download
            Logger.Info("Build {0} is not available, downloading...", build.ID);

            // If the builds folder does not exists, create it
            Locations.EnsureBuildsFolder();

            // Create the Uri and destination location
            string Destination = Path.Combine(Locations.Temp, build.ID + (Checks.IsWindows ? ".zip" : ".tar.xz"));

            // If we didn't managed to download the file
            if (!await Downloader.DownloadFile(string.Format(DownloadBuild, build.ID), Destination))
            {
                return;
            }

            // Log that we have finished the download
            Logger.Info("The download of build {0} has finished, starting extraction...", build.ID);

            // Install the build from the ZIP file
            await Install(Destination, build.ID);

            // Delete the temporary ZIP file
            File.Delete(Destination);
        }

        public static async Task Install(string file, string name = null)
        {
            // If the name is null or whitespaces
            if (string.IsNullOrWhiteSpace(name))
            {
                // Hash the file and use that as the name
                using (FileStream stream = File.OpenRead(file))
                using (BufferedStream buffered = new BufferedStream(stream))
                using (SHA1Managed sha = new SHA1Managed())
                {
                    byte[] checksum = sha.ComputeHash(buffered);
                    string hash = BitConverter.ToString(checksum).Replace("-", "").ToLowerInvariant();

                    name = $"custom-{hash}";
                }
            }

            // Create the path of the folder
            string path = Path.Combine(Locations.BuildsForOS, name);

            // If the current build folder exists, delete it
            if (Directory.Exists(path))
            {
                Directory.Delete(path, true);
            }
            // Create the folder for the files
            Directory.CreateDirectory(path);

            // Finally, extract the values
            await Compression.Extract(file, path);

            // Log that we have finished the extraction
            Logger.Info("Build {0} is now available for the server", name);
        }
    }
}
