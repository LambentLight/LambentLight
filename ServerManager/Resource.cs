using Newtonsoft.Json;

namespace ServerManager
{
    /// <summary>
    /// Type of resource.
    /// </summary>
    public enum ResourceType
    {
        Gamemode = 0,
        Script = 1
    }

    /// <summary>
    /// Type of compression used for the file.
    /// </summary>
    public enum CompressionType
    {
        Zip = 0,
        SevenZip = 1
    }

    /// <summary>
    /// Information about of the resource that is going to be installed.
    /// </summary>
    public class Resource
    {
        /// <summary>
        /// The name of the resource.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }
        /// <summary>
        /// Path of the resource inside of the compressed file.
        /// </summary>
        [JsonProperty("path")]
        public string Path { get; set; }
        /// <summary>
        /// Output folder name for the resource.
        /// </summary>
        [JsonProperty("folder")]
        public string Folder { get; set; }
        /// <summary>
        /// Download link for the resource.
        /// </summary>
        [JsonProperty("download")]
        public string Download { get; set; }
        /// <summary>
        /// Type of resource being installed.
        /// </summary>
        [JsonProperty("type")]
        public ResourceType Type { get; set; }
        /// <summary>
        /// Compression used for the downloaded file.
        /// </summary>
        [JsonProperty("compression")]
        public CompressionType Compresion { get; set; }
    }
}
