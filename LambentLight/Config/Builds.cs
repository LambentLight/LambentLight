using Newtonsoft.Json;

namespace LambentLight.Config
{
    /// <summary>
    /// The configuration item for storing the location of the builds.
    /// </summary>
    public class Builds
    {
        [JsonProperty("windows")]
        public string Windows { get; set; } = "https://raw.githubusercontent.com/LambentLight/Metadata/master/builds/fivem.json";
    }
}
