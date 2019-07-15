using Newtonsoft.Json;
using System;

namespace LambentLight
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
        SevenZip = 1,
        Rar = 2
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
        /// Readable version of the mod.
        /// </summary>
        [JsonProperty("version")]
        public string Version { get; set; }
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
        /// License to show the user.
        /// </summary>
        [JsonProperty("license")]
        public string License { get; set; }
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

        /// <summary>
        /// Gets the extension of the resource based on the compression format.
        /// </summary>
        /// <returns>The .ext extension.</returns>
        public string GetExtension()
        {
            switch (Compresion)
            {
                case CompressionType.Zip:
                    return ".zip";
                case CompressionType.SevenZip:
                    return ".7z";
                case CompressionType.Rar:
                    return ".rar";
                default:
                    throw new SystemException("How did we get here?");
            }
        }
    }
}
