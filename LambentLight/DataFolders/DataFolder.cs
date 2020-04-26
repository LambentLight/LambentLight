using Newtonsoft.Json;
using Serilog;
using System.IO;
using System.Windows.Forms;

namespace LambentLight.DataFolders
{
    /// <summary>
    /// Class for managing a specific Data Folder.
    /// </summary>
    public class DataFolder
    {
        #region Properties

        /// <summary>
        /// If this Data Folder is valid or not.
        /// </summary>
        public bool Valid { get; private set; }
        /// <summary>
        /// The name of the folder.
        /// </summary>
        public string Name { get; private set; }
        /// <summary>
        /// The absolute location of the folder.
        /// </summary>
        public string Location { get; private set; }
        /// <summary>
        /// The LambentLight configuration for a specific Server Data folder.
        /// </summary>
        public DataFolderConfig Config { get; private set; }

        #endregion

        #region Constructor

        public DataFolder(string folder)
        {
            // If the folder specified does not exists, raise an exception
            if (!Directory.Exists(folder))
            {
                throw new DirectoryNotFoundException("The directory of the Data Folder was not found");
            }

            // Save the name and absolute location
            Name = Path.GetFileName(folder);
            Location = Path.GetFullPath(folder);
            // Set it as invalid for now
            Valid = false;

            string path = Path.Combine(Location, "LambentLight.json");
            // If the configuration file does not exists, create a new one
            if (!File.Exists(path))
            {
                Config = new DataFolderConfig();
                Log.Information($"Configuration Created for Data Folder {Location}");
                SaveConfig();
                Valid = true;
            }
            // Otherwise
            else
            {
                string config = File.ReadAllText(path);
                // Try to load it and set the Data Folder as valid
                try
                {
                    Config = JsonConvert.DeserializeObject<DataFolderConfig>(config);
                    Log.Information($"Configuration Loaded for Data Folder {Location}");
                    Valid = true;
                }
                // If we failed, ask the user about what to do
                catch (JsonException e)
                {
                    Log.Error(e, $"Unable to load Data Folder Configuration of {Location}");
                    // Ask the user if he wants to restore it to default
                    DialogResult result = MessageBox.Show($"The Data Folder configuration for {Name} is invalid\nDo you want to restore it to defaults?", "Invalid Data Folder Configuration", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                    if (result == DialogResult.Yes)
                    {
                        Config = new DataFolderConfig();
                        Log.Information($"Configuration Overriden for Data Folder {Location}");
                        SaveConfig();
                        Valid = true;
                    }
                }
            }
        }

        #endregion

        #region Public Functions

        /// <summary>
        /// Saves the Data Folder Configuration.
        /// </summary>
        public void SaveConfig()
        {
            string path = Path.Combine(Location, "LambentLight.json");
            string config = JsonConvert.SerializeObject(Config);
            File.WriteAllText(path, config);
        }
        /// <summary>
        /// Returns the name of the data folder.
        /// </summary>
        public override string ToString() => Name;

        #endregion
    }
}
