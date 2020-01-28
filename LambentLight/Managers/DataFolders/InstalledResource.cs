using Newtonsoft.Json;
using NLog;
using System.IO;

namespace LambentLight.Managers.DataFolders
{
    #region Enums

    public enum MetadataType
    {
        Invalid = -1,
        ResourceLua = 0,
        FXManifest = 1,
    }

    #endregion

    /// <summary>
    /// Class that handles a
    /// </summary>
    public class InstalledResource
    {
        #region Private Fields

        /// <summary>
        /// The logger for our current class.
        /// </summary>
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        #endregion

        #region Public Properties

        /// <summary>
        /// The name of the resource.
        /// </summary>
        [JsonProperty("name")]
        public string Name => Path.GetFileNameWithoutExtension(Location);
        /// <summary>
        /// Where the resource is located.
        /// </summary>
        [JsonIgnore]
        public string Location { get; }
        /// <summary>
        /// The Data Folder where this resource is located.
        /// </summary>
        [JsonIgnore]
        public DataFolder Source { get; }
        /// <summary>
        /// The type of metadata file that this resource has
        /// </summary>
        [JsonProperty("metadata_type")]
        public MetadataType MetadataType
        {
            get
            {
                // If fxmanifest.lua exists
                if (File.Exists(Path.Combine(Location, "fxmanifest.lua")))
                {
                    return MetadataType.FXManifest;
                }
                // If __resource.lua exists
                else if (File.Exists(Path.Combine(Location, "__resource.lua")))
                {
                    return MetadataType.ResourceLua;
                }
                // Otherwise, return -1
                else
                {
                    return MetadataType.Invalid;
                }
            }
        }

        /// <summary>
        /// Checks if a resource is present on the specified folder.
        /// </summary>
        [JsonIgnore]
        public bool IsPresent => Directory.Exists(Location);

        #endregion

        #region Constructor

        public InstalledResource(DataFolder source, string location)
        {
            Source = source;
            Location = location;
        }

        #endregion

        #region Public Functions

        /// <summary>
        /// Removes the resource if is present.
        /// </summary>
        public void Remove()
        {
            // If the resource exists and is present
            if (IsPresent)
            {
                // If the user wants to remove the configuration value for auto start, do it
                if (Program.Config.RemoveAfterUninstalling)
                {
                    Source.RemoveFromAutoStart(this);
                }

                // Delete the resource
                Directory.Delete(Location, true);
                // And notify the user
                Logger.Warn("Removing existing version of {0} at '{1}' (from Data Folder '{2}')", Name, Location, Source);
            }
            // If not
            else
            {
                // Notify the user
                Logger.Error("The resource {0} could not be found in '{1}' (from Data Folder '{2}')", Name, Location, Source);
            }
        }

        #endregion

        #region Overrides

        public override string ToString() => Name;

        #endregion
    }
}
