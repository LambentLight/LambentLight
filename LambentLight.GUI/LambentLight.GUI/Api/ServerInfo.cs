using Newtonsoft.Json;

namespace LambentLight.GUI.Api
{
    /// <summary>
    /// Represents the information of a LambentLight Server.
    /// </summary>
    public class ServerInfo
    {
        /// <summary>
        /// The name of the program running on the server.
        /// </summary>
        [JsonProperty("prog")]
        public string ProgramName { get; set; }
        /// <summary>
        /// The version of LambentLight running on the Server.
        /// </summary>
        [JsonProperty("version")]
        public string Version { get; set; }
    }
}
