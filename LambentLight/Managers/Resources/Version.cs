using Newtonsoft.Json;

namespace LambentLight.Managers.Resources
{
    /// <summary>
    /// The specific version information of a resource.
    /// </summary>
    public class Version
    {
        #region Public Properties

        /// <summary>
        /// The readable version. This can be either semantic versioning or the git commit.
        /// </summary>
        [JsonProperty("version", Required = Required.Always)]
        public string ReadableVersion { get; set; }
        /// <summary>
        /// The place where we can download the resource with the specific version.
        /// </summary>
        [JsonProperty("download", Required = Required.Always)]
        public string Download { get; set; }
        /// <summary>
        /// The Path of the resource inside of the compressed files.
        /// This take precedence over the Resource Path.
        /// </summary>
        [JsonProperty("path")]
        public string Path { get; set; }

        #endregion

        #region Overrides

        /// <summary>
        /// Gets the readable version of the resource.
        /// </summary>
        /// <returns>The readable version of the resource.</returns>
        public override string ToString() => ReadableVersion;

        #endregion
    }
}
