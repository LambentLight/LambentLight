using Flurl.Http;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LambentLight.GUI.API
{
    /// <summary>
    /// Represnets a Data Folder stored in the server.
    /// </summary>
    public class DataFolder
    {
        internal Client client;

        /// <summary>
        /// The name of the Data Folder.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }
        /// <summary>
        /// The Path to the data folder in the Server's file system.
        /// </summary>
        [JsonProperty("path")]
        public string Path { get; set; }

        /// <summary>
        /// Gets the string representation of a Data Folder.
        /// </summary>
        /// <returns>The Name of the Data Folder.</returns>
        public override string ToString() => Name;

        /// <summary>
        /// Gets the list of Resources present on this Data Folder.
        /// </summary>
        /// <returns>A List with the Resources installed on this Data Folder.</returns>
        public async Task<List<InstalledResource>> GetResources()
        {
            try
            {
                List<InstalledResource> folders = await client.client.Request($"/folders/{Name}/resources").GetJsonAsync<List<InstalledResource>>();
                foreach (InstalledResource resource in folders)
                {
                    resource.client = client;
                    resource.Folder = this;
                }
                return folders;
            }
            catch (FlurlHttpException)
            {
                return new List<InstalledResource>();
            }
        }
    }
}
