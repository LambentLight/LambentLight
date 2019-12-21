using LambentLight.Managers.DataFolders;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;

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
        /// <summary>
        /// The extended information for this resource.
        /// </summary>
        [JsonIgnore]
        public ExtendedResource More
        {
            get
            {
                if (more == null)
                {
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
                    more = Downloader.DownloadJSON<ExtendedResource>($"{Repo}/resources/{game}/{Name}.json");
                }
                return more;
            }
        }

        #endregion

        #region Public Functions


        /// <summary>
        /// Collects all resources required for an install.
        /// </summary>
        /// <param name="resource"></param>
        /// <returns></returns>
        public Dictionary<Resource, Version> GetRequirements(Version version, int level = 0)
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
            if (More.Requires != null)
            {
                // Iterate over the requirements
                foreach (string requirement in More.Requires)
                {
                    // First, try to find the version on this resource
                    Resource found = ResourceManager.Resources.Where(res => res.Name == requirement).FirstOrDefault();

                    // If the resource exists and is not on the list
                    if (found != null && !resources.ContainsKey(found))
                    {
                        // Collect their requirements
                        Dictionary<Resource, Version> requirements = found.GetRequirements(found.More.Versions[0], level + 1);

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
