using LambentLight.Properties;
using Newtonsoft.Json;
using NLog;
using System;
using System.Collections.Generic;
using System.IO;
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
        /// The updated list of builds.
        /// </summary>
        public static List<Build> Builds = new List<Build>();

        /// <summary>
        /// Refreshes the list of builds.
        /// </summary>
        public static void Refresh()
        {
            // Create a temporary list of builds
            List<Build> NewBuilds = Downloader.DownloadJSON<List<Build>>(Settings.Default.BuildsWindows, new BuildConverter()) ?? new List<Build>();
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
            // Log that we are starting the download
            Logger.Info("Build {0} is not available, downloading...", build.ID);

            // If the builds folder does not exists, create it
            Locations.EnsureBuildsFolder();

            // Create the Uri and destination location
            string Destination = Path.Combine(Locations.Temp, build.ID + ".zip");

            // If we didn't managed to download the file
            if (!await Downloader.DownloadFile($"https://runtime.fivem.net/artifacts/fivem/build_server_windows/master/{build.ID}/server.zip", Destination))
            {
                return;
            }

            // Log that we have finished the download
            Logger.Info("The download of build {0} has finished, starting extraction...", build.ID);

            // If the current build folder exists, delete it
            if (build.IsAvailable)
            {
                Directory.Delete(build.Folder, true);
            }
            // Create the folder for the files
            Directory.CreateDirectory(build.Folder);

            // Finally, extract the values
            await Compression.ExtractZip(Destination, build.Folder);

            // Log that we have finished the extraction
            Logger.Info("Build {0} is now available for the server", build.ID);

            // Delete the temporary ZIP file
            File.Delete(Destination);
        }
    }
}
