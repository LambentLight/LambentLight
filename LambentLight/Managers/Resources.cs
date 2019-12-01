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
        [JsonProperty("path", Required = Required.Default)]
        public string Path { get; set; }

        /// <summary>
        /// Gets the readable version of the resource.
        /// </summary>
        /// <returns>The readable version of the resource.</returns>
        public override string ToString() => ReadableVersion;
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
        /// The name of the folder of the resource.
        /// </summary>
        [JsonProperty("folder", Required = Required.Always)]
        public string Folder { get; set; }
        /// <summary>
        /// The Path of the resource inside of the compressed files.
        /// </summary>
        [JsonProperty("path", Required = Required.Default)]
        public string Path { get; set; }
        /// <summary>
        /// The URL of the license page.
        /// </summary>
        [JsonProperty("license", Required = Required.Default)]
        public string License { get; set; }
        /// <summary>
        /// The list of requirements of the resource.
        /// </summary>
        [JsonProperty("requires", Required = Required.Default)]
        public List<string> Requires { get; set; }
        /// <summary>
        /// The resource configuration instructions by the author.
        /// </summary>
        [JsonProperty("instructions", Required = Required.Default)]
        public string ConfigInstructions { get; set; }
        /// <summary>
        /// A list with the versions of the resource.
        /// </summary>
        [JsonProperty("versions", Required = Required.Default)]
        public List<Version> Versions { get; set; }

        /// <summary>
        /// Checks if a specific resource is installed on a Data Folder.
        /// </summary>
        /// <param name="folder">The folder to check against to.</param>
        /// <returns>true if the resource is installed, false otherwise.</returns>
        public bool IsInstalledIn(DataFolder folder)
        {
            // Format the path of the folder
            string Location = System.IO.Path.Combine(folder.Resources, Folder);
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
            if (resource.Requires != null)
            {
                // For every requirement
                foreach (string Requirement in resource.Requires)
                {
                    // Try to find a resource with that name
                    Resource Found = Resources.Where(res => res.Name == Requirement).FirstOrDefault();

                    // If the resource exists and is not on the list
                    if (Found != null && !TempList.ContainsKey(Found))
                    {
                        // Collect their requirements
                        Dictionary<Resource, Version> NewReqs = GetRequirements(Found, Found.Versions[0]);

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
            // Create a temporary list of resources
            List<Resource> Output = Downloader.DownloadJSON<List<Resource>>(Settings.Default.Resources, new BuildConverter());
            // Store the resources in alphabetical order
            Resources = (Output ?? new List<Resource>()).OrderBy(x => x.Name).ToList();
            // Log what we have just done
            Logger.Debug("The list of resources has been updated");
        }
    }
}
