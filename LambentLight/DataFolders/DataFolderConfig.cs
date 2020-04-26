using Newtonsoft.Json;

namespace LambentLight.DataFolders
{
    /// <summary>
    /// Configuration of a specific Data Folder.
    /// </summary>
    public class DataFolderConfig
    {
        /// <summary>
        /// If this data folder should use the most up to date build.
        /// </summary>
        [JsonProperty("use_recent")]
        public bool UseRecent { get; set; } = true;
        /// <summary>
        /// The a specific build to use for this Data Folder.
        /// </summary>
        [JsonProperty("specific_build")]
        public string SpecificBuild { get; set; } = "";
        /// <summary>
        /// The desired game for this Data Folder.
        /// </summary>
        [JsonProperty("game")]
        public Game Game { get; set; } = Game.GrandTheftAutoV;
        /// <summary>
        /// The name of the main Server Configuration file.
        /// </summary>
        [JsonProperty("config")]
        public string Config { get; set; } = "server.cfg";
    }
}
