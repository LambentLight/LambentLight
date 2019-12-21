using Newtonsoft.Json;

namespace LambentLight.Managers.Resources
{
    /// <summary>
    /// The parameters used for installing the resource.
    /// </summary>
    public class InstallInfo
    {
        #region Public Properties

        /// <summary>
        /// The folder where the resource should be installed.
        /// </summary>
        [JsonProperty("destination", Required = Required.Always)]
        public string Destination { get; set; }

        #endregion
    }
}
