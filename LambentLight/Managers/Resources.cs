using Newtonsoft.Json;
using NLog;
using System.Collections.Generic;
using System.Net;

namespace LambentLight.Managers
{
    /// <summary>
    /// Identifies the type of a resource.
    /// </summary>
    public enum ResourceType
    {
        /// <summary>
        /// A simple script.
        /// </summary>
        Script = 0,
        /// <summary>
        /// A completely different gamemode.
        /// </summary>
        GameMode = 1,
        /// <summary>
        /// A new loading screen.
        /// </summary>
        LoadingScreen = 2
    }

    /// <summary>
    /// The type of compression used for the 
    /// </summary>
    public enum CompressionType
    {
        /// <summary>
        /// The classic ZIP file.
        /// </summary>
        Zip = 0,
        /// <summary>
        /// 7zip or Seven ZIP.
        /// </summary>
        SevenZip = 1,
        /// <summary>
        /// RAR from WinRAR.
        /// </summary>
        Rar = 2
    }

    /// <summary>
    /// The specific version information of a resource.
    /// </summary>
    public class Version
    {
        /// <summary>
        /// The readable version. This can be either semantic versioning or the git commit.
        /// </summary>
        [JsonProperty("version")]
        public string ReadableVersion { get; set; }
        /// <summary>
        /// The place where we can download the resource with the specific version.
        /// </summary>
        [JsonProperty("download")]
        public string Download { get; set; }

        /// <summary>
        /// The Path of the resource inside of the compressed files.
        /// This take precedence over the Resource Path.
        /// </summary>
        [JsonProperty("path")]
        public string Path { get; set; }
        /// <summary>
        /// The compression used for the download.
        /// </summary>
        [JsonProperty("compression")]
        public CompressionType Compression { get; set; }

        /// <summary>
        /// Gets the extension for the compression type.
        /// </summary>
        /// <returns>The .ext extension.</returns>
        public string GetExtension()
        {
            switch (Compression)
            {
                case CompressionType.Zip:
                    return ".zip";
                case CompressionType.SevenZip:
                    return ".7z";
                case CompressionType.Rar:
                    return ".rar";
                default:
                    throw new System.InvalidOperationException($"{(int)Compression} is not a valid compression type");
            }
        }

        public override string ToString()
        {
            return ReadableVersion;
        }
    }

    /// <summary>
    /// Class that contains the informatioon of a specific downloadable resource.
    /// </summary>
    public class Resource
    {
        /// <summary>
        /// The readable name of the resource.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }
        /// <summary>
        /// The creator of the resource.
        /// </summary>
        [JsonProperty("author")]
        public string Author { get; set; }
        /// <summary>
        /// The name of the folder of the resource.
        /// </summary>
        [JsonProperty("folder")]
        public string Folder { get; set; }
        /// <summary>
        /// The Path of the resource inside of the compressed files.
        /// </summary>
        [JsonProperty("path")]
        public string Path { get; set; }
        /// <summary>
        /// The type of resource. Only used for the UI.
        /// </summary>
        [JsonProperty("type")]
        public ResourceType Type { get; set; }
        /// <summary>
        /// The URL of the license page.
        /// </summary>
        [JsonProperty("license")]
        public string License { get; set; }
        /// <summary>
        /// A list with the versions of the resource.
        /// </summary>
        [JsonProperty("versions")]
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

        public override string ToString()
        {
            return Name;
        }
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
        /// Refreshes the list of resources.
        /// </summary>
        public static void Refresh()
        {
            // Let's store the fetched resources here
            string RawResources = "";

            // Try to request the list of resources
            try
            {
                // Use a context manager
                using (WebClient Client = new WebClient())
                {
                    RawResources = Client.DownloadString(Properties.Settings.Default.Resources);
                }
            }
            // If we have failed (4XX-5XX codes)
            catch (WebException e)
            {
                // Set the resource list to empty
                Resources = new List<Resource>();
                // Notify the user
                Logger.Error("Unable to fetch the new FiveM builds: Code {0} ({1})", (int)e.Status, e.Status);
                return;
            }

            // Create a temporary list of resources
            Resources = JsonConvert.DeserializeObject<List<Resource>>(RawResources, new BuildConverter());

            // Log what we have just done
            Logger.Debug("The list of resources has been updated");
        }
    }
}
