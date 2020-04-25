using Flurl.Http;
using Newtonsoft.Json;
using Serilog;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace LambentLight.Builds
{
    /// <summary>
    /// Manager for builds.
    /// </summary>
    public class BuildManager : BaseManager
    {
        #region Fields

        /// <summary>
        /// The location of the cache file.
        /// </summary>
        private readonly string cacheFile = Path.Combine("cache", "builds.json");

        #endregion

        #region Properties

        /// <summary>
        /// The builds available for download.
        /// </summary>
        public List<Build> Builds { get; private set; } = new List<Build>();

        #endregion

        #region Public Functions

        /// <summary>
        /// Updates the cache from the GitHub repository.
        /// </summary>
        public override async Task Update()
        {
            Log.Information("Starting update of the CFX Builds");
            // Get the builds from the repository
            Builds builds = await Program.Config.DownloadBuilds.GetJsonAsync<Builds>();
            // Save them for later use
            Builds = builds.RemoteBuilds;
            Log.Information("Finished update of the CFX Builds");
            // And save them to the cache
            SaveCache();
        }
        /// <summary>
        /// Loads the builds from the cache if they have been written recently.
        /// </summary>
        /// <returns>True if they were loaded from the drive, false otherwise.</returns>
        public override bool LoadCache()
        {
            // If the file does not exists, return
            if (!File.Exists(cacheFile))
            {
                Log.Warning("Cache for the Builds is not present");
                return false;
            }
            // If the file is old, return
            if (File.GetLastWriteTimeUtc(cacheFile) < (DateTime.UtcNow + TimeSpan.FromHours(6)))
            {
                Log.Warning("Cache for the Builds is older than 6 hours");
                return false;
            }

            // Otherwise, try to load it
            try
            {
                string cache = File.ReadAllText(cacheFile);
                Builds = JsonConvert.DeserializeObject<List<Build>>(cache);
                Log.Information("CFX Build cache was loaded");
                return true;
            }
            catch (JsonReaderException e)
            {
                Log.Error(e, "Error while loading the Build cache");
                return false;
            }
        }
        /// <summary>
        /// Saves the builds into the drive for later use.
        /// </summary>
        public override void SaveCache()
        {
            // Create the cache directory if it does not exists
            Directory.CreateDirectory("cache");
            // Just write the entire list of builds into the cache
            File.WriteAllText(cacheFile, JsonConvert.SerializeObject(Builds));
            Log.Information("CFX Build cache was saved");
        }

        #endregion
    }
}
