using Newtonsoft.Json;
using NLog;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Net;
using System.Threading.Tasks;

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
        public string Folder => Path.Combine(Properties.Settings.Default.FolderBuilds, ID);

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
        /// <returns>The ID of the build.</returns>
        public override string ToString() => ID;

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
        /// The Uri or URL for downloading the builds from the FiveM servers.
        /// </summary>
        public const string DownloadUri = "https://runtime.fivem.net/artifacts/fivem/build_server_windows/master/{0}/server.zip";
        /// <summary>
        /// The updated list of builds.
        /// </summary>
        public static List<Build> Builds = new List<Build>();

        /// <summary>
        /// Refreshes the list of builds.
        /// </summary>
        public static void Refresh()
        {
            // Let's store the fetched builds here
            string RawBuilds = "";

            // Try to request the list of builds
            try
            {
                // Use a context manager
                using (WebClient Client = new WebClient())
                {
                    RawBuilds = Client.DownloadString(Properties.Settings.Default.Builds);
                }
            }
            // If we have failed (4XX-5XX codes)
            catch (WebException e)
            {
                // Set the build list to empty
                Builds = new List<Build>();
                // Notify the user
                Logger.Error("Unable to fetch the new FiveM builds: Code {0} ({1})", (int)e.Status, e.Status);
                return;
            }

            // Create a temporary list of builds
            Builds = JsonConvert.DeserializeObject<List<Build>>(RawBuilds, new BuildConverter());

            // Log what we have just done
            Logger.Info("The list of builds has been updated");
        }

        /// <summary>
        /// Downloads the specified build.
        /// </summary>
        /// <param name="build">The build to download.</param>
        public static async Task Download(Build build)
        {
            // Log that we are starting the download
            Logger.Info("Build {0} is not available, attempting download...", build.ID);

            // If the builds folder does not exists, create it
            if (!Directory.Exists(Properties.Settings.Default.FolderBuilds))
            {
                Directory.CreateDirectory(Properties.Settings.Default.FolderBuilds);
            }

            // Create the Uri and destination location
            string Destination = Path.Combine(Properties.Settings.Default.FolderTemp, build.ID + ".zip");

            // Use a context manager
            using (WebClient Client = new WebClient())
            {
                // Start downloading the file
                await Client.DownloadFileTaskAsync(string.Format(DownloadUri, build.ID), Destination);

                // While the client is bussy, wait
                while (Client.IsBusy)
                {
                    await Task.Delay(0);
                }
            }

            // If the current build folder exists, delete it
            if (build.IsAvailable)
            {
                Directory.Delete(build.Folder, true);
            }
            // Create the folder for the files
            Directory.CreateDirectory(build.Folder);

            // Finally, extract the values
            await Task.Run(() => ZipFile.ExtractToDirectory(Destination, build.Folder));

            // Delete the temporary ZIP file
            File.Delete(Destination);

            // Log that we have finished the download
            Logger.Info("The download of build {0} has finished", build.ID);
        }
    }
}
