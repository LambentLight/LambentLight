using LambentLight.Config;
using NLog;
using System.Collections.Generic;
using System.Linq;

namespace LambentLight.Managers.Resources
{
    /// <summary>
    /// Class that manages the resources of the installer.
    /// </summary>
    public static class ResourceManager
    {
        #region Private Fields

        /// <summary>
        /// The logger for our current class.
        /// </summary>
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        #endregion

        #region Public Properties

        /// <summary>
        /// All of the resources that are available for installing.
        /// </summary>
        public static List<Resource> Resources { get; private set; } = new List<Resource>();

        #endregion

        #region Public Functions

        /// <summary>
        /// Adds the specified enumerator of resources into the list.
        /// </summary>
        /// <param name="resources"></param>
        public static void Add(ref List<Resource> tempResources, List<Resource> newResources, Compatibility compatibility, string repo)
        {
            // If one of the lists is null, return
            if (tempResources == null || newResources == null)
            {
                return;
            }

            // Iterate over the list of resources in the new one
            foreach (Resource resource in newResources)
            {
                // Get the first resource matching the name
                Resource found = tempResources.Where(x => x.Name == resource.Name).FirstOrDefault();

                // If the big list of resources contains this one, skip it
                if (found != null)
                {
                    Logger.Warn("Repository {0} already contains resource {1}, skipping...", found.Repo, found.Name);
                    continue;
                }

                // Save the repo and game
                resource.Repo = repo;
                resource.Compatibility = compatibility;
                // Otherwise, add it
                tempResources.Add(resource);
            }
        }
        /// <summary>
        /// Refreshes the list of resources.
        /// </summary>
        public static void Refresh()
        {
            // Create a new list of resources
            List<Resource> tempResources = new List<Resource>();
            // Get the readable name of the game
            string game = Program.Config.Game == Game.GrandTheftAutoV ? "gtav" : "rdr2";

            // For each resource repository
            foreach (string repo in Program.Config.Repos)
            {
                // Get the lists of resources
                List<Resource> outputGeneric = Downloader.DownloadJSON<List<Resource>>($"{repo}/resources/common.json");
                List<Resource> outputGame = Downloader.DownloadJSON<List<Resource>>($"{repo}/resources/{game}.json");

                // And add them
                Add(ref tempResources, outputGeneric, Compatibility.Common, repo);
                Add(ref tempResources, outputGame, (Compatibility)Program.Config.Game, repo);
            }

            // Store the resources in alphabetical order
            Resources = tempResources.OrderBy(x => x.Name).ToList();
            // Log what we have just done
            Logger.Debug("The list of resources has been updated");
        }

        #endregion
    }
}
