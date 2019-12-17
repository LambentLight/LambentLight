using Newtonsoft.Json;
using NLog;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace LambentLight.Managers
{
    /// <summary>
    /// The specific version information of a resource.
    /// </summary>
    public class Version
    {
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

        /// <summary>
        /// Gets the readable version of the resource.
        /// </summary>
        /// <returns>The readable version of the resource.</returns>
        public override string ToString() => ReadableVersion;
    }

    /// <summary>
    /// The parameters used for installing the resource.
    /// </summary>
    public class InstallInfo
    {
        /// <summary>
        /// The folder where the resource should be installed.
        /// </summary>
        [JsonProperty("destination", Required = Required.Always)]
        public string Destination { get; set; }
    }

    /// <summary>
    /// The extended information of a resource.
    /// </summary>
    public class ExtendedResource
    {
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
    }

    /// <summary>
    /// Class that contains the informatioon of a specific downloadable resource.
    /// </summary>
    public class Resource
    {
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
        /// The extended information for this resource.
        /// </summary>
        [JsonIgnore]
        public ExtendedResource More { get; set; }

        /// <summary>
        /// Checks if a specific resource is installed on a Data Folder.
        /// </summary>
        /// <param name="folder">The folder to check against to.</param>
        /// <returns>true if the resource is installed, false otherwise.</returns>
        public bool IsInstalledIn(DataFolder folder)
        {
            // If there is no More parameter, return
            if (More == null)
            {
                return false;
            }

            // Format the path of the folder
            string Location = Path.Combine(folder.Resources, More.Install.Destination);
            // Return if the folder exists
            return Directory.Exists(Location);
        }

        public override string ToString() => $"{Name} by {Author}";
    }

    /// <summary>
    /// Class that manages the resources of the installer.
    /// </summary>
    public static class ResourceManager
    {
        /// <summary>
        /// The logger for our current class.
        /// </summary>
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();
        /// <summary>
        /// All of the resources that are available for installing.
        /// </summary>
        public static List<Resource> Resources = new List<Resource>();

        /// <summary>
        /// Collects all resources required for an install.
        /// </summary>
        /// <param name="resource"></param>
        /// <returns></returns>
        public static Dictionary<Resource, Version> GetRequirements(Resource resource, Version version)
        {
            // Create a dictionary of resources and versions
            Dictionary<Resource, Version> TempList = new Dictionary<Resource, Version>();
            // Add our base resource and version
            TempList.Add(resource, version);

            // If we have dependencies
            if (resource.More.Requires != null)
            {
                // For every requirement
                foreach (string Requirement in resource.More.Requires)
                {
                    // Try to find a resource with that name
                    Resource Found = Resources.Where(res => res.Name == Requirement).FirstOrDefault();

                    // If the resource exists and is not on the list
                    if (Found != null && !TempList.ContainsKey(Found))
                    {
                        // Collect their requirements
                        Dictionary<Resource, Version> NewReqs = GetRequirements(Found, Found.More.Versions[0]);

                        // For every new requirement found
                        foreach (KeyValuePair<Resource, Version> NewReq in NewReqs)
                        {
                            // If is not on the list, add it
                            if (!TempList.ContainsKey(NewReq.Key))
                            {
                                TempList.Add(NewReq.Key, NewReq.Value);
                            }
                        }
                    }
                }
            }

            // Finally, return the list
            return TempList;
        }
        /// <summary>
        /// Refreshes the list of resources.
        /// </summary>
        public static void Refresh()
        {
            // Create a dummy list of resources
            List<Resource> resources = new List<Resource>();

            // For each resource repository
            foreach (string repo in Program.Config.Repos)
            {
                // Combine the repo with the resource metadata
                string url = $"{repo}/resources/list.json";
                // Create a temporary list of resources
                List<Resource> output = Downloader.DownloadJSON<List<Resource>>(url);

                // Iterate over the list of resources
                foreach (Resource resource in output)
                {
                    // Get the first resource matching the name
                    Resource found = resources.Where(x => x.Name == resource.Name).FirstOrDefault();

                    // If the big list of resources contains this one, skip it
                    if (found != null)
                    {
                        Logger.Warn("Repository {0} already contains resource {1}, skipping...", found.Repo, found.Name);
                        continue;
                    }

                    // Save the repo where they came from
                    resource.Repo = repo;
                    // Otherwise, add it
                    resources.Add(resource);
                }
            }

            // Store the resources in alphabetical order
            Resources = resources.OrderBy(x => x.Name).ToList();
            // Log what we have just done
            Logger.Debug("The list of resources has been updated");
        }
    }
}
