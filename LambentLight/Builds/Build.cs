using Newtonsoft.Json;

namespace LambentLight.Builds
{
    /// <summary>
    /// The Target Operating System for a build.
    /// </summary>
    public enum TargetOS
    {
        Windows = 0,
        Linux = 1
    }

    /// <summary>
    /// Object that stores the information of a build.
    /// </summary>
    public class Build
    {
        /// <summary>
        /// The name or identifier of the build.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }
        /// <summary>
        /// The Download URL of the build.
        /// </summary>
        [JsonProperty("download")]
        public string Download { get; set; }
        /// <summary>
        /// Target Operating System for the build.
        /// </summary>
        [JsonProperty("target")]
        public TargetOS Target { get; set; }
    }
}
