using Newtonsoft.Json;
using NLog;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace LambentLight.Managers.Builds
{
    /// <summary>
    /// Class that contains the information of a specific CFX build.
    /// </summary>
    public class Build
    {
        #region Private Fields

        /// <summary>
        /// The logger for our current class.
        /// </summary>
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();
        /// <summary>
        /// RegEx for checking if a build is from CFX.
        /// </summary>
        private const string CFXRegEx = "([0-9]{3,4}-[0-9a-z]{40})";
        /// </summary>
        /// The download URL for a specific operating system.
        /// </summary>
        private static readonly string DownloadBuild = "https://runtime.fivem.net/artifacts/fivem/build_server_windows/master/{0}/server.zip";

        #endregion

        #region Public Properties

        /// <summary>
        /// The ID of the build. This can be either the folder name or SHA1 hash.
        /// </summary>
        [JsonProperty("id")]
        public string ID { get; private set; }
        /// <summary>
        /// The local folder where the build can be located.
        /// </summary>
        [JsonIgnore]
        public string Folder { get; private set; }
        /// <summary>
        /// The location of the CFX Server executable.
        /// </summary>
        [JsonIgnore]
        public string Executable { get; private set; }
        /// <summary>
        /// If the server executable is present.
        /// </summary>
        [JsonProperty("exe_present")]
        public bool IsExecutablePresent => File.Exists(Executable);
        /// <summary>
        /// If the folder for the build exists.
        /// </summary>
        [JsonProperty("folder_present")]
        public bool IsFolderPresent => Directory.Exists(Folder);
        /// <summary>
        /// If this is an official build from the CitizenFX Collective.
        /// </summary>
        [JsonProperty("is_cfx")]
        public bool IsCFX => Regex.IsMatch(ID, CFXRegEx);

        #endregion

        #region Constructor

        /// <summary>
        /// Creates a Build to use with LambentLight
        /// </summary>
        /// <param name="identifier">The folder name or Upstream identifier.</param>
        public Build(string identifier)
        {
            // Set our identifier
            ID = identifier;
            // And the other properties that we need
            Folder = Path.Combine(Locations.Builds, ID);
            Executable = Path.Combine(Folder, "FXServer.exe");
        }

        #endregion

        #region Public Functions

        /// <summary>
        /// Downloads this build from the CFX Servers.
        /// </summary>
        public async Task<bool> Download()
        {
            // Log that we are starting the download
            Logger.Info("Downloading Build {0}...", ID);

            // Make sure that the Builds folder exists
            Locations.EnsureBuildsFolder();

            // Create the Uri and destination location
            string downloadPath = Path.Combine(Locations.Temp, ID + ".zip");
            // Try to download the file from the location
            bool success = await Downloader.DownloadFileAsync(string.Format(DownloadBuild, ID), downloadPath);

            // If the download was not completed, return failure
            if (!success)
            {
                return false;
            }

            // Tell the manager to install the build
            await BuildManager.Install(downloadPath, ID);
            // Delete the temporary ZIP file
            File.Delete(downloadPath);

            // At this point, return success
            return true;
        }

        #endregion

        #region Overrides

        /// <summary>
        /// Gets the string representation of a build.
        /// </summary>
        public override string ToString() => ID + " " + (IsExecutablePresent ? "(Ready to Use)" : "(Requires Download)");
        /// <summary>
        /// Gets the Hash of the Build Identifier.
        /// </summary>
        public override int GetHashCode() => ID.GetHashCode();
        /// <summary>
        /// Checks if the compared object has the same ID as the current one.
        /// </summary>
        public override bool Equals(object obj) => obj is Build && ID == ((Build)obj).ID;

        #endregion
    }
}
