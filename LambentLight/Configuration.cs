using Newtonsoft.Json;

namespace LambentLight
{
    /// <summary>
    /// Class used for the program configuration.
    /// </summary>
    public class Configuration
    {
        /// <summary>
        /// The last build used by the player.
        /// </summary>
        [JsonProperty("last_build")]
        public string LastBuild { get; set; } = null;

        /// <summary>
        /// The page that contains the download list of the CFX Builds.
        /// </summary>
        [JsonProperty("download_builds")]
        public string DownloadBuilds { get; set; } = "https://raw.githubusercontent.com/LambentLight/Builds/master/builds.json";
    }
}
