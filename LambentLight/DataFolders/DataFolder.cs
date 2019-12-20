using LambentLight.Database;
using LambentLight.Managers;
using MySql.Data.MySqlClient;
using NLog;
using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LambentLight.DataFolders
{
    /// <summary>
    /// A class that represents a folder with FiveM server data.
    /// </summary>
    public class DataFolder
    {
        #region Private Fields

        /// <summary>
        /// The logger for our current class.
        /// </summary>
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();
        /// <summary>
        /// The secure Random Number Generator for RCON passwords.
        /// </summary>
        private static readonly RNGCryptoServiceProvider RNG = new RNGCryptoServiceProvider();

        #endregion

        #region Public Properties

        /// <summary>
        /// The name of the folder.
        /// </summary>
        public string Name { get; private set; }
        /// <summary>
        /// The location of the server data folder
        /// </summary>
        public string Location { get; private set; }
        /// <summary>
        /// The path of the Configuration file.
        /// </summary>
        public string ConfigurationPath { get; private set; }
        /// <summary>
        /// The location of the resources folder.
        /// </summary>
        public string Resources { get; private set; }
        /// <summary>
        /// If the data folder exists.
        /// </summary>
        public bool Exists => Directory.Exists(Location);
        /// <summary>
        /// The resources that are currently installed on the data folder.
        /// </summary>
        public List<InstalledResource> InstalledResources
        {
            get
            {
                // Create a temp list of resources
                List<InstalledResource> resources = new List<InstalledResource>();

                // Iterate over the directories in the resources folder
                foreach (string folder in Directory.EnumerateDirectories(Resources, "*", SearchOption.AllDirectories))
                {
                    // If the folder contains a resource metadata version 1 (__resource.lua) or 2 (fxmanifest.lua), add it
                    if (File.Exists(Path.Combine(folder, "__resource.lua")) || File.Exists(Path.Combine(folder, "fxmanifest.lua")))
                    {
                        resources.Add(new InstalledResource(this, folder));
                    }
                }

                // Finally, return the installed resources
                return resources;
            }
        }
        /// <summary>
        /// The server configuration for the data folder.
        /// </summary>
        public string Configuration
        {
            get
            {
                // If there is a server configuration file
                if (File.Exists(ConfigurationPath))
                {
                    return string.Join(Environment.NewLine, File.ReadAllLines(ConfigurationPath)) + Environment.NewLine;
                }
                // Otherwise, return a generic string
                return "# This server data folder does not has a configuration file";
            }
            set
            {
                // Write the string to the configuration file
                File.WriteAllText(ConfigurationPath, value);
                // Log that we just saved the configuration
                Logger.Info("The configuration of {0} has been saved", Name);
            }
        }

        #endregion

        #region Constructors

        /// <summary>
        /// Creates a new instance of the data folder.
        /// </summary>
        /// <param name="name">The name of the folder inside of Data.</param>
        public DataFolder(string name)
        {
            Name = name;
            Location = Path.Combine(Locations.Data, Name);
            ConfigurationPath = Path.Combine(Location, "server.cfg");
            Resources = Path.Combine(Location, "resources");
        }

        #endregion

        #region Public Functions

        /// <summary>
        /// Generates a new configuration for the current data folder.
        /// </summary>
        /// <returns>The new configuration as a string.</returns>
        public string GenerateConfig(string rconPassword = null, bool allowScriptHook = false)
        {
            // Get the base configuration
            string baseConfig = Encoding.UTF8.GetString(Properties.Resources.ConfigurationTemplate);

            // If there is no RCON Password, generate one
            if (string.IsNullOrWhiteSpace(rconPassword))
            {
                // Create a place to store the output
                byte[] randomBytes = new byte[32];
                // Create the random string as bytes
                RNG.GetBytes(randomBytes);
                // And then, return that byte array as a string
                rconPassword = Convert.ToBase64String(randomBytes);
            }

            // Convert the bool of the ScriptHook setting to a string with a number
            string scriptHook = allowScriptHook ? "1" : "0";
            // To generate the new configuration
            string newConfig = string.Format(baseConfig, rconPassword, scriptHook);

            // And finally, save the configuration and return it
            Configuration = newConfig;
            return newConfig;
        }

        /// <summary>
        /// Installs the specified resource and version on the data folder.
        /// </summary>
        /// <param name="resource">The resource information.</param>
        /// <param name="version">The version to install.</param>
        /// <param name="installRequirements">If the resource requirements should be installed.</param>
        /// <returns>true if the installation succeded, false otherwise.</returns>
        public async Task InstallResource(Resource resource, Managers.Version version, bool installRequirements = true)
        {
            // Notify that we are starting the install of there resource
            Logger.Info("Installing resource {0} {1}", resource.Name, version.ReadableVersion);

            // Format a path for the output file
            string ExtractionPath = Path.Combine(Locations.Temp, $"{resource.More.Install.Destination}-{version.ReadableVersion}");
            string TempFilePath = ExtractionPath + Path.GetExtension(version.Download);

            // Select the correct path inside of the extraction folder
            // In order: Version Path, Resource Path or an Empty String
            string CompressedPath = version.Path ?? "";
            // Create the path for the folder that we need to move
            string ChoosenFolder = Path.Combine(ExtractionPath, CompressedPath);
            // Create the destination directory (aka the path inside of the resources directory)
            string DestinationFolder = Path.Combine(Resources, resource.More.Install.Destination);
            // Format the path where the version can be located
            string versionPath = Path.Combine(DestinationFolder, "version.lambentlight");

            // If the version file exists and matches the version that we are trying to install, log it and return
            if (File.Exists(versionPath) && File.ReadAllText(versionPath) == version.ReadableVersion)
            {
                Logger.Info("Resource {0} {1} is already installed", resource.Name, version.ReadableVersion);
                return;
            }

            // If the temporary folder does not exists
            Locations.EnsureTempFolder();
            // If the temp file exists
            if (File.Exists(TempFilePath))
            {
                // Yeet it
                File.Delete(TempFilePath);
            }

            // If the we tried to download the file and we ended up failing, return
            if (!await Downloader.DownloadFile(version.Download, TempFilePath))
            {
                return;
            }

            // If the resources folder does not exists
            if (!Directory.Exists(Resources))
            {
                // Create it
                Directory.CreateDirectory(Resources);
            }

            // For every installed resource
            foreach (InstalledResource Installed in InstalledResources)
            {
                // If the name matches the resource that we are going to install
                if (Installed.Name == resource.More.Install.Destination)
                {
                    // Delete/Dispose it
                    Installed.Dispose();
                }
            }

            // If the output directory exists
            if (Directory.Exists(ExtractionPath))
            {
                // Remove it
                Directory.Delete(ExtractionPath, true);
            }

            // Create the temporary extraction directory
            Directory.CreateDirectory(ExtractionPath);

            // Notify that we are starting the extraction of the file
            Logger.Info("Extracting {0} {1}...", resource.Name, version.ReadableVersion);
            // Try to extract the file
            try
            {
                await Compression.Extract(TempFilePath, ExtractionPath);
            }
            // If we fail, log the error message and return
            catch (InvalidOperationException e)
            {
                Logger.Error(e.Message);
                return;
            }

            // Remove the temporary compressed file
            File.Delete(TempFilePath);

            // If there is a database running and we want to apply the patches
            if (DatabaseManager.Connection != null && Program.Config.MySQL.Apply)
            {
                // Get all of the SQL files
                foreach (string file in Directory.EnumerateFiles(ExtractionPath, "**.sql", SearchOption.AllDirectories))
                {
                    // If we need a manual confirmation for the file
                    if (Program.Config.MySQL.Manually)
                    {
                        // Get the name of the file
                        string name = Path.GetFileName(file);
                        // Ask the user if he wants to confirm the SQL patch
                        DialogResult result = MessageBox.Show($"Do you want to apply the file {name} into the MySQL Database?", "SQL File Found", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        // If he does not, continue to the next iteration
                        if (result == DialogResult.No)
                        {
                            continue;
                        }
                    }

                    // Get the contents of the file
                    string sql = File.ReadAllText(file);
                    // Create the MySQL Command
                    using (MySqlCommand command = new MySqlCommand(sql, DatabaseManager.Connection))
                    {
                        // And execute it
                        await command.ExecuteNonQueryAsync();
                    }
                }
            }

            /*
            // If the resource has aditional configuration instructions
            if (resource.ConfigInstructions != null)
            {
                // Ask the user if he wants to open the configuration instructions
                DialogResult Result = MessageBox.Show($"The resource {resource.Name} requires aditional configuration\nDo you want to open the configuration instructions in your browser?", "Configuration required", MessageBoxButtons.YesNo);

                // If it does
                if (Result == DialogResult.Yes)
                {
                    // Open it up
                    Process.Start(resource.ConfigInstructions);
                }
            }
            */

            // Try to move the folder with the resource
            try
            {
                Directory.Move(ChoosenFolder, DestinationFolder);
            }
            // If the directory was not found, notify the user and return
            catch (DirectoryNotFoundException)
            {
                Logger.Error("Unable to find '{0}' inside of the file", CompressedPath);
            }

            // And delete the temporary folder if it exists
            if (Directory.Exists(ExtractionPath))
            {
                Directory.Delete(ExtractionPath, true);
            }

            // If we got here, write a file with the current version
            File.WriteAllText(versionPath, version.ReadableVersion);

            // Finally, notify that we have finished
            Logger.Info("Done! {0} {1} has been installed", resource.Name, version.ReadableVersion);
        }

        /// <summary>
        /// Deletes the existing folder and creates it again.
        /// </summary>
        public async Task Recreate(string rconPassword = null, bool allowScriptHook = false)
        {
            // Literally dispose the existing folder
            Remove();
            // Then call the create data folder again
            await DataFolderManager.Create(Name, rconPassword, allowScriptHook);
        }

        /// <summary>
        /// Deletes the folder.
        /// </summary>
        public void Remove()
        {
            // If the folder exists
            if (Exists)
            {
                // Delete it
                Directory.Delete(Location, true);
            }
        }

        #endregion

        #region Overrides

        /// <summary>
        /// Gets the directory name.
        /// </summary>
        /// <returns>The name of the directory.</returns>
        public override string ToString() => Name;
        /// <summary>
        /// Gets the Hash of the Build Identifier.
        /// </summary>
        public override int GetHashCode() => Name.GetHashCode();
        /// <summary>
        /// Checks if the compared object has the same name as the current one.
        /// </summary>
        public override bool Equals(object obj) => obj is DataFolder && Name == ((DataFolder)obj).Name;

        #endregion
    }
}
