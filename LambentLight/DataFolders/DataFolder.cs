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
        /// <returns>true if the installation succeded, false otherwise.</returns>
        public async Task Install(Resource resource, Managers.Version version)
        {
            // Notify that we are starting the install of there resource
            Logger.Info("Installing resource {0} {1}", resource.Name, version.ReadableVersion);

            // Format a path for the temporary extraction and download locations
            string extractionPath = Path.Combine(Locations.Temp, $"{resource.More.Install.Destination}-{version.ReadableVersion}");
            string downloadPath = extractionPath + Path.GetExtension(version.Download);

            // Create the path of the folder that contains the resource itself
            string resourcePath = Path.Combine(extractionPath, version.Path ?? "");
            // Create the path where the resource should be installed
            string destinationFolder = Path.Combine(Resources, resource.More.Install.Destination);
            // Create the path where the version can be located
            string versionPath = Path.Combine(destinationFolder, "version.lambentlight");

            // If the version file exists and matches one that we are trying to install, log it and return
            if (File.Exists(versionPath) && File.ReadAllText(versionPath) == version.ReadableVersion)
            {
                Logger.Info("Resource {0} {1} is already installed, skipping...", resource.Name, version.ReadableVersion);
                return;
            }

            // Make sure that the temporary download folder exists
            Locations.EnsureTempFolder();
            // If there is something in the temporary download location, remove it
            if (File.Exists(downloadPath))
            {
                File.Delete(downloadPath);
            }

            // Try to download the file
            // If we failed, return and do nothing
            if (!await Downloader.DownloadFile(version.Download, downloadPath))
            {
                return;
            }

            // If the resources folder does not exists, create it
            if (!Directory.Exists(Resources))
            {
                Directory.CreateDirectory(Resources);
            }

            // Iterate over the list of installed resources
            foreach (InstalledResource Installed in InstalledResources)
            {
                // If the name matches the resource that we are trying to install, delete it
                if (Installed.Name == resource.More.Install.Destination)
                {
                    Installed.Dispose();
                }
            }

            // If the extraction location exists, remove it
            if (Directory.Exists(extractionPath))
            {
                Directory.Delete(extractionPath, true);
            }
            // Create the temporary extraction directory
            Directory.CreateDirectory(extractionPath);

            // Try to extract the file
            try
            {
                await Compression.Extract(downloadPath, extractionPath);
            }
            // If we failed, log the error message and return
            catch (InvalidOperationException e)
            {
                Logger.Error(e.Message);
                return;
            }

            // Remove the temporary compressed file
            File.Delete(downloadPath);

            // If there is a database running and we want to apply the patches
            if (DatabaseManager.Connection != null && Program.Config.MySQL.Apply)
            {
                // Get all of the SQL files
                foreach (string file in Directory.EnumerateFiles(extractionPath, "**.sql", SearchOption.AllDirectories))
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

            // Try to move the folder with the resource
            try
            {
                Directory.Move(resourcePath, destinationFolder);
            }
            // If the directory was not found, notify the user and return
            catch (DirectoryNotFoundException)
            {
                Logger.Error("Unable to find '{0}' inside of the file", resourcePath);
            }

            // If the temporary extraction directory exists, remove it
            if (Directory.Exists(extractionPath))
            {
                Directory.Delete(extractionPath, true);
            }

            // If we got here, write a file with the current version
            File.WriteAllText(versionPath, version.ReadableVersion);

            // And finally, notify that we have finished
            Logger.Info("Done! {0} {1} has been installed", resource.Name, version.ReadableVersion);
        }
        /// <summary>
        /// Deletes the existing data folder and creates it again.
        /// </summary>
        /// <param name="rconPassword">The password .</param>
        /// <param name="allowScriptHook"></param>
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
            // If the folder exists, delete it
            if (Exists)
            {
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
