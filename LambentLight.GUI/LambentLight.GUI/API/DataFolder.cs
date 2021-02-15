using Newtonsoft.Json;

namespace LambentLight.GUI.API
{
    /// <summary>
    /// Represnets a Data Folder stored in the server.
    /// </summary>
    public class DataFolder
    {
        internal Client client;

        /// <summary>
        /// The name of the Data Folder.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }
        /// <summary>
        /// The Path to the data folder in the Server's file system.
        /// </summary>
        [JsonProperty("path")]
        public string Path { get; set; }

        /// <summary>
        /// Gets the string representation of a Data Folder.
        /// </summary>
        /// <returns>The Name of the Data Folder.</returns>
        public override string ToString() => Name;
    }
}
