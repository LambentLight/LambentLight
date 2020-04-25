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
        /// The name of the main Server Configuration file.
        /// </summary>
        [JsonProperty("config")]
        public string Config { get; set; } = "server.cfg";
    }
}
