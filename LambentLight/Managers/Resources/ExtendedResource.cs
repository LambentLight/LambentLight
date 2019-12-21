using Newtonsoft.Json;
using System.Collections.Generic;

namespace LambentLight.Managers.Resources
{
    /// <summary>
    /// The extended information of a resource.
    /// </summary>
    public class ExtendedResource
    {
        #region Public Properties

        /// <summary>
        /// The list of resources that this one requires.
        /// </summary>
        [JsonProperty("requires")]
        public List<string> Requires { get; set; } = new List<string>();
        /// <summary>
        /// Information used for installing the resource.
        /// </summary>
        [JsonProperty("install", Required = Required.Always)]
        public InstallInfo Install { get; set; }
        /// <summary>
        /// The versions that this resource contains.
        /// </summary>
        [JsonProperty("versions", Required = Required.Always)]
        public List<Version> Versions { get; set; }

        #endregion
    }
}
