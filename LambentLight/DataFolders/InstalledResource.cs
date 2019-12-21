using NLog;
using System;
using System.IO;
using System.Text.RegularExpressions;

namespace LambentLight.DataFolders
{
    /// <summary>
    /// Class that handles a
    /// </summary>
    public class InstalledResource : IDisposable
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
        public string Name => Path.GetFileNameWithoutExtension(Location);
        /// <summary>
        /// Where the resource is located.
        /// </summary>
        public string Location { get; }
        /// <summary>
        /// The Data Folder where this resource is located.
        /// </summary>
        public DataFolder Source { get; }

        /// <summary>
        /// Checks if a resource is present on the specified folder.
        /// </summary>
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
        public void Dispose()
        {
            // If the resource exists and is present
            if (IsPresent)
            {
                // If the user wants to remove the configuration value during the uninstall process
                if (Program.Config.RemoveAfterUninstalling)
                {
                    // Create the RegEx pattern for this specific resource
                    string Pattern = string.Format(Patterns.Resource, Name);
                    // If there is a match inside of the configuration
                    if (Regex.IsMatch(Source.Configuration, Pattern))
                    {
                        // Remove it
                        Source.Configuration = Regex.Replace(Source.Configuration, Pattern, string.Empty);
                    }
                }

                // Delete the resource
                Directory.Delete(Location, true);
                // And notify the user
                Logger.Warn("Removing existing version of {0} at '{1}' (from Data Folder '{2}')", Name, Location, Source.Name);
            }
            // If not
            else
            {
                // Notify the user
                Logger.Error("The resource {0} could not be found in '{1}' (from Data Folder '{2}')", Name, Location, Source.Name);
            }
        }

        #endregion

        #region Overrides

        public override string ToString() => Name;

        #endregion
    }
}
