using Newtonsoft.Json;

namespace LambentLight.DataFolders
{
    /// <summary>
    /// Configuration of a specific Data Folder.
    /// </summary>
    public class DataFolderConfig
    {
        /// <summary>
        /// The desired game for this Data Folder.
        /// </summary>
        [JsonProperty("game")]
        public Game Game { get; set; } = Game.GrandTheftAutoV;
        /// <summary>
        /// If this Data Folder should use a custom license.
        /// </summary>
        [JsonProperty("license_usecustom")]
        public bool LicenseUseCustom { get; set; } = false;
        /// <summary>
        /// A custom CFX License to use.
        /// </summary>
        [JsonProperty("license_custom")]
        public string LicenseCustom { get; set; } = "";
        /// <summary>
        /// If this data folder should use the most up to date build.
        /// </summary>
        [JsonProperty("build_recent")]
        public bool BuildUseRecent { get; set; } = true;
        /// <summary>
        /// The a specific build to use for this Data Folder.
        /// </summary>
        [JsonProperty("build_specific")]
        public string BuildSpecific { get; set; } = "";
        /// <summary>
        /// If OneSync should be enabled or not.
        /// </summary>
        [JsonProperty("onesync")]
        public bool OneSync { get; set; } = false;
        /// <summary>
        /// If OneSync Infinity should be enabled or not.
        /// </summary>
        [JsonProperty("onesyncinf")]
        public bool OneSyncInfinity { get; set; } = false;
        /// <summary>
        /// The name of the main Server Configuration file.
        /// </summary>
        [JsonProperty("config")]
        public string Config { get; set; } = "server.cfg";
    }
}
