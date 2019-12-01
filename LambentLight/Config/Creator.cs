using Newtonsoft.Json;

namespace LambentLight.Config
{
    /// <summary>
    /// The configuration for the Data Folder Creator.
    /// </summary>
    public class Creator
    {
        [JsonProperty("download_scripts")]
        public bool DownloadScripts { get; set; } = true;
        [JsonProperty("create_config")]
        public bool CreateConfig { get; set; } = true;
        [JsonProperty("shv_enabled")]
        public bool SHVEnabled { get; set; } = false;
    }
}
