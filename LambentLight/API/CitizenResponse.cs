using Newtonsoft.Json;
using System.Collections.Generic;

namespace LambentLight.API
{
    /// <summary>
    /// Information sent by the server in JSON.
    /// </summary>
    public class CitizenResponse
    {
        [JsonProperty("enhancedHostSupport")]
        public bool EnhancedHostSupport { get; set; }
        [JsonProperty("resources")]
        public List<string> Resources { get; set; }
        [JsonProperty("server")]
        public string Server { get; set; }
        [JsonProperty("vars")]
        public Dictionary<string, string> ConVars { get; set; }
        [JsonProperty("version")]
        public uint Version { get; set; }
    }
}
