using Newtonsoft.Json;

namespace LambentLight.GUI.API
{
    /// <summary>
    /// Represents a resource installed on a specific Data Folder.
    /// </summary>
    public class InstalledResource
    {
        internal Client client;

        /// <summary>
        /// The Data Folder that this resource corresponds to.
        /// </summary>
        [JsonIgnore]
        public DataFolder Folder { get; set; }
        /// <summary>
        /// The name of the Resource.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }
        /// <summary>
        /// The Path of the Resource.
        /// </summary>
        [JsonProperty("path")]
        public string Path { get; set; }
        /// <summary>
        /// The location of the CFX Manifest.
        /// </summary>
        [JsonProperty("manifest")]
        public string Manifest { get; set; }

        /// <summary>
        /// Gets the Name of the Resource.
        /// </summary>
        /// <returns>The Name of the Resource.</returns>
        public override string ToString() => Name;
    }
}
