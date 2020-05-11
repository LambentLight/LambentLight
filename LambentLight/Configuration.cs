using Newtonsoft.Json;
using Serilog;
using System.IO;
using System.Windows.Forms;

namespace LambentLight
{
    /// <summary>
    /// Class used for the program configuration.
    /// </summary>
    public class Configuration
    {
        /// <summary>
        /// The name of the configuration file.
        /// </summary>
        [JsonIgnore]
        private const string filename = "LambentLight.json";
        /// <summary>
        /// The settings used for the JSON Serialization.
        /// </summary>
        [JsonIgnore]
        private static readonly JsonSerializerSettings settings = new JsonSerializerSettings()
        {
            ObjectCreationHandling = ObjectCreationHandling.Replace
        };

        /// <summary>
        /// The page that contains the download list of the CFX Builds.
        /// </summary>
        [JsonProperty("download_builds")]
        public string DownloadBuilds { get; set; } = "https://raw.githubusercontent.com/LambentLight/Builds/master/builds.json";

        /// <summary>
        /// The Server License key.
        /// </summary>
        [JsonProperty("token_cfx")]
        public string CFXLicense { get; set; } = "";
        /// <summary>
        /// The Steam API Token for Steam Identifiers.
        /// </summary>
        [JsonProperty("token_steam")]
        public string SteamKey { get; set; } = "";

        /// <summary>
        /// Saves the configuration.
        /// </summary>
        public void Save()
        {
            // Convert the configuration to a string
            string content = JsonConvert.SerializeObject(this);
            // And write it to the correct file
            File.WriteAllText(filename, content);
        }

        /// <summary>
        /// Loads the configuration.
        /// </summary>
        public static Configuration Load()
        {
            // If the configuration file exists
            if (File.Exists(filename))
            {
                // Read the contents of it
                string contents = File.ReadAllText(filename);
                // And try to parse it
                try
                {
                    return JsonConvert.DeserializeObject<Configuration>(contents, settings);
                }
                // If we failed
                catch (JsonSerializationException e)
                {
                    // Log the error
                    Log.Error(e, "Unable to load settings");
                    Log.Error("Asking user about what to do next");
                    // And ask the user what to do
                    DialogResult result = MessageBox.Show("The configuration file is invalid.\n\nDo you want to delete the configuration and create a new one?\nIf you say no, the application will be closed.", "Configuration is not valid", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                    // If he said yes, recreate it
                    if (result == DialogResult.Yes)
                    {
                        return Recreate();
                    }
                    // Otherwise, return null
                    else
                    {
                        return null;
                    }
                }
            }
            // If is not, return a new configuration file
            else
            {
                return Recreate();
            }
        }
        /// <summary>
        /// Creates a new server configuration.
        /// </summary>
        public static Configuration Recreate()
        {
            Configuration config = new Configuration();
            config.Save();
            return config;
        }
    }
}
