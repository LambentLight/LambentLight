using Newtonsoft.Json;
using System.Collections.Generic;

namespace LambentLight.API
{
    /// <summary>
    /// Player information returned by the CitizenFX Server.
    /// </summary>
    public class CitizenPlayer
    {
        [JsonProperty("endpoint")]
        public string Endpoint { get; set; }
        [JsonProperty("id")]
        public uint ID { get; set; }
        [JsonProperty("identifiers")]
        public List<string> Identifiers { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("ping")]
        public uint Ping { get; set; }
    }
}
