using LambentLight.Managers.DataFolders;
using Newtonsoft.Json;
using System.IO;

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

        #region Functions

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
            string Location = Path.Combine(folder.ResourcesPath, More.Install.Destination);
            // Return if the folder exists
            return Directory.Exists(Location);
        }

        #endregion

        #region Overrides

        public override string ToString() => $"{Name} by {Author}";

        #endregion
    }
}
