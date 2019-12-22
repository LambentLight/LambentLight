using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace LambentLight.Config
{
    /// <summary>
    /// The currently choosen game.
    /// </summary>
    public enum Game
    {
        GrandTheftAutoV = 0,
        RedDeadRedemption2 = 1
    }
    /// <summary>
    /// Different time things.
    /// </summary>
    public enum Time
    {
        Seconds = 0,
        Minutes = 1
    }

    /// <summary>
    /// Object used for the configuration of LambentLight.
    /// </summary>
    public class Configuration
    {
        [JsonIgnore]
        public const string FolderBuilds = "builds";
        [JsonIgnore]
        public const string FolderData = "data";
        [JsonIgnore]
        public const string FolderTemp = "temp";

        [JsonProperty("game")]
        public Game Game { get; set; } = Game.GrandTheftAutoV;
        [JsonProperty("cfx_token")]
        public string CFXToken { get; set; } = "";
        [JsonProperty("steam_token")]
        public string SteamToken { get; set; } = "";
        [JsonProperty("restart_on_crash")]
        public bool RestartOnCrash { get; set; } = true;
        [JsonProperty("clear_cache")]
        public bool ClearCache { get; set; } = false;
        [JsonProperty("wait")]
        public bool Wait { get; set; } = true;
        [JsonProperty("wait_meas")]
        public Time WaitMeasurement { get; set; } = Time.Seconds;
        [JsonProperty("wait_time")]
        public int WaitTime { get; set; } = 60;
        [JsonProperty("kick_everyone")]
        public bool KickEveryone { get; set; } = true;
        [JsonProperty("repos")]
        public List<string> Repos { get; set; } = new List<string>()
        {
            "https://raw.githubusercontent.com/LambentLight/Metadata/master",
        };
        [JsonProperty("add_after_installing")]
        public bool AddAfterInstalling { get; set; } = false;
        [JsonProperty("remove_after_uninstalling")]
        public bool RemoveAfterUninstalling { get; set; } = false;
        [JsonProperty("builds")]
        public string Builds { get; set; } = "https://raw.githubusercontent.com/LambentLight/Metadata/master";
        [JsonProperty("mysql")]
        public MySQL MySQL { get; set; } = new MySQL();
        [JsonProperty("creator")]
        public Creator Creator { get; set; } = new Creator();
        [JsonProperty("auto_restart")]
        public AutoRestart AutoRestart { get; set; } = new AutoRestart();

        private static string GetConfigLocation()
        {
            // Get the assembly that is calling 
            Assembly assembly = Assembly.GetCallingAssembly();
            // Get the location of the DLL that is using this function
            string location = new Uri(Path.GetDirectoryName(assembly.CodeBase)).LocalPath;
            // Then, make the path based on the assembly name and path and return it
            return Path.Combine(location, $"{assembly.GetName().Name}.json");
        }
        public static Configuration Load()
        {
            // Get the location of the configuration
            string path = GetConfigLocation();

            // Then, if the file exist
            if (File.Exists(path))
            {
                // Get the contents of the file
                string contents = File.ReadAllText(path);
                // And return the parsed contents
                return JsonConvert.DeserializeObject<Configuration>(contents, new JsonSerializerSettings() { ObjectCreationHandling = ObjectCreationHandling.Replace });
            }
            // If not
            else
            {
                // And return it
                return Regenerate();
            }
        }
        public static Configuration Regenerate()
        {
            // Create a new configuration object
            Configuration config = new Configuration();
            // Save it
            config.Save();
            // And return it
            return config;
        }
        public void Save()
        {
            // Get the output of the serialization
            string output = JsonConvert.SerializeObject(this, Formatting.Indented) + Environment.NewLine;
            // And dump the contents of the file
            File.WriteAllText(GetConfigLocation(), output);
        }
    }
}
