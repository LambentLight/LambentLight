using Newtonsoft.Json;

namespace LambentLight.Config
{
    /// <summary>
    /// Configuration for the MySQL patches.
    /// </summary>
    public class MySQL
    {
        [JsonProperty("connection")]
        public string Connection { get; set; } = "";
        [JsonProperty("apply")]
        public bool Apply { get; set; } = true;
        [JsonProperty("manually")]
        public bool Manually { get; set; } = true;
    }
}
