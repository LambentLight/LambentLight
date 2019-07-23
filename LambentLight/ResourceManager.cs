using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LambentLight
{
    /// <summary>
    /// Identifies the type of a resource.
    /// </summary>
    public enum ResourceType
    {
        /// <summary>
        /// A simple script.
        /// </summary>
        Script = 0,
        /// <summary>
        /// A completely different gamemode.
        /// </summary>
        GameMode = 1,
        /// <summary>
        /// A new loading screen.
        /// </summary>
        LoadingScreen = 2
    }

    /// <summary>
    /// The type of compression used for the 
    /// </summary>
    public enum CompressionType
    {
        /// <summary>
        /// The classic ZIP file.
        /// </summary>
        Zip = 0,
        /// <summary>
        /// 7zip or Seven ZIP.
        /// </summary>
        SevenZip = 1,
        /// <summary>
        /// RAR from WinRAR.
        /// </summary>
        Rar = 2
    }

    /// <summary>
    /// The specific version information of a resource.
    /// </summary>
    public class Version
    {
        /// <summary>
        /// The readable version. This can be either semantic versioning or the git commit.
        /// </summary>
        [JsonProperty("version")]
        public string ReadableVersion { get; set; }
        /// <summary>
        /// The place where we can download the resource with the specific version.
        /// </summary>
        [JsonProperty("download")]
        public string Download { get; set; }
        /// <summary>
        /// The compression used for the download.
        /// </summary>
        [JsonProperty("compression")]
        public CompressionType Compression { get; set; }
    }

    /// <summary>
    /// Class that contains the informatioon of a specific downloadable resource.
    /// </summary>
    public class Resource
    {
        /// <summary>
        /// The readable name of the resource.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }
        /// <summary>
        /// The creator of the resource.
        /// </summary>
        [JsonProperty("author")]
        public string Author { get; set; }
        /// <summary>
        /// The name of the folder of the resource.
        /// </summary>
        [JsonProperty("folder")]
        public string Folder { get; set; }
        /// <summary>
        /// The type of resource. Only used for the UI.
        /// </summary>
        [JsonProperty("type")]
        public ResourceType Type { get; set; }
        /// <summary>
        /// The URL of the license page.
        /// </summary>
        [JsonProperty("license")]
        public string License { get; set; }
        /// <summary>
        /// A list with the versions of the resource.
        /// </summary>
        [JsonProperty("versions")]
        public List<Version> Versions { get; set; }
    }

    /// <summary>
    /// Class that manages the resources of the installer.
    /// </summary>
    public static class ResourceManager
    {
        /// <summary>
        /// All of the resources that are available for installing.
        /// </summary>
        public static List<Resource> Resources = new List<Resource>();
    }
}
