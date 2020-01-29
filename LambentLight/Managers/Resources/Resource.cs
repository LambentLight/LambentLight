using LambentLight.Managers.DataFolders;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace LambentLight.Managers.Resources
{
    /// <summary>
    /// Class that contains the informatioon of a specific downloadable resource.
    /// </summary>
    public class Resource
    {
        #region Private Fields

        /// <summary>
        /// The private extended information.
        /// </summary>
        private ExtendedResource more = null;

        #endregion

        #region Public Properties

        /// <summary>
        /// The readable name of the resource.
        /// </summary>
        [JsonProperty("name", Required = Required.Always)]
        public string Name { get; set; }
        /// <summary>
        /// The creator of the resource.
        /// </summary>
        [JsonProperty("author", Required = Required.Always)]
        public string Author { get; set; }
        /// <summary>
        /// If this resource is deprecated, the one that replaces it.
        /// </summary>
        [JsonProperty("superseded")]
        public string SupersededBy { get; set; }
        /// <summary>
        /// The repo that has the information of this resource.
        /// </summary>
        [JsonIgnore]
        public string Repo { get; set; }
        /// <summary>
        /// The compatibility of this resource.
        /// </summary>
        [JsonIgnore]
        public Compatibility Compatibility { get; set; }

        #endregion

        #region Public Functions

        /// <summary>
        /// Collects all of the resources required for this one to be installed.
        /// </summary>
        /// <param name="version">The version of this resource to use.</param>
        /// <returns>A dictionary with the Resource(s) as a Key and the Version(s) as a Value.</returns>
        public async Task<Dictionary<Resource, Version>> GetRequirements(Version version)
        {
            return await GetRequirements(version, 0);
        }

        /// <summary>
        /// Gets the extended information of the resource.
        /// </summary>
        /// <returns>The extended resource information.</returns>
        public async Task<ExtendedResource> GetExtendedInformation()
        {
            // If there is no extended information
            if (more == null)
            {
                // Get the correct game name for the resource compatibility
                string game;
                switch (Compatibility)
                {
                    case Compatibility.GrandTheftAutoV:
                        game = "gtav";
                        break;
                    case Compatibility.RedDeadRedemption2:
                        game = "rdr2";
                        break;
                    default:
                        game = "common";
                        break;
                }
                // And request the extended resource information
                more = await Downloader.DownloadJSONAsync<ExtendedResource>($"{Repo}/resources/{game}/{Name}.json");
            }

            // At this point, we should have the extended information
            // Just return it
            return more;
        }

        #endregion

        #region Private Functions

        /// <summary>
        /// Collects all of the resources required for this one to be installed.
        /// </summary>
        /// <param name="version">The version of this resource to use.</param>
        /// <param name="level">The level of nested calls.</param>
        /// <returns>A dictionary with the Resource(s) as a Key and the Version(s) as a Value.</returns>
        private async Task<Dictionary<Resource, Version>> GetRequirements(Version version, int level)
        {
            // Create a dictionary of resources and versions
            Dictionary<Resource, Version> resources = new Dictionary<Resource, Version>();

            // If we are 3 levels deep with nested calls, return
            if (level >= 3)
            {
                return resources;
            }

            // Add our existing resource and version
            resources.Add(this, version);

            // If the current resource has more requirements
            if ((await GetExtendedInformation()).Requires != null)
            {
                // Iterate over the requirements
                foreach (string requirement in (await GetExtendedInformation()).Requires)
                {
                    // First, try to find the version on this resource
                    Resource found = ResourceManager.Resources.Where(res => res.Name == requirement).FirstOrDefault();

                    // If the resource exists and is not on the list
                    if (found != null && !resources.ContainsKey(found))
                    {
                        // Collect their requirements
                        Dictionary<Resource, Version> requirements = await found.GetRequirements((await found.GetExtendedInformation()).Versions[0], level + 1);

                        // For every new requirement found
                        foreach (KeyValuePair<Resource, Version> newRequirement in requirements)
                        {
                            // If is not on the list, add it
                            if (!resources.ContainsKey(newRequirement.Key))
                            {
                                resources.Add(newRequirement.Key, newRequirement.Value);
                            }
                        }
                    }
                }
            }

            // Finally, return the list
            return resources;
        }

        #endregion

        #region Overrides

        public override string ToString() => $"{Name} by {Author}";

        #endregion
    }
}
