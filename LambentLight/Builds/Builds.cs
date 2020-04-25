using Newtonsoft.Json;
using System.Collections.Generic;

namespace LambentLight.Builds
{
    /// <summary>
    /// Base class for the list of builds.
    /// </summary>
    public class Builds
    {
        /// <summary>
        /// The schema used to validate the list of builds.
        /// </summary>
        [JsonProperty("$schema")]
        public string Schema { get; set; }
        /// <summary>
        /// The builds that are available for download.
        /// </summary>
        [JsonProperty("builds")]
        public List<Build> RemoteBuilds { get; set; }
    }
}
