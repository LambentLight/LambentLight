using Newtonsoft.Json;

namespace LambentLight.Config
{
    /// <summary>
    /// The settings for the LambentLight API.
    /// </summary>
    public class WebAPI
    {
        [JsonProperty("enabled")]
        public bool Enabled { get; set; } = true;
        [JsonProperty("bind")]
        public string BindTo { get; set; } = "http://127.0.0.1:4810";
        [JsonProperty("token")]
        public string Token { get; set; } = Program.GenerateSecureString();
    }
}
