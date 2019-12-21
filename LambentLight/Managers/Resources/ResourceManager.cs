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
        /// Refreshes the list of resources.
        /// </summary>
        public static void Refresh()
        {
            // Create a new temporary list of resources
            List<Resource> tempResources = new List<Resource>();
            // Get the readable name of the game that is currently selected
            string game = Program.Config.Game == Game.GrandTheftAutoV ? "gtav" : "rdr2";

            // For each resource repository
            foreach (string repo in Program.Config.Repos)
            {
                // Get the lists of resources that are common and specific to this game
                List<Resource> outputGeneric = Downloader.DownloadJSON<List<Resource>>($"{repo}/resources/common.json");
                List<Resource> outputGame = Downloader.DownloadJSON<List<Resource>>($"{repo}/resources/{game}.json");

                // And add them
                Add(ref tempResources, outputGeneric, Compatibility.Common, repo);
                Add(ref tempResources, outputGame, (Compatibility)Program.Config.Game, repo);
            }

            // Store the resources in alphabetical order
            Resources = tempResources.OrderBy(x => x.Name).ToList();
            // And log what we have just done
            Logger.Debug("The list of resources has been updated");
        }

        #endregion

        #region Private Functions

        /// <summary>
        /// Adds a list of resources onto another one while avoiding duplicates.
        /// </summary>
        /// <param name="tempResources">The list to add the resources onto.</param>
        /// <param name="newResources">The list of new resources that are going to be added.</param>
        /// <param name="compatibility">The game compatibility of the new resource.</param>
        /// <param name="repo">The repository URL for the new resources.</param>
        public static void Add(ref List<Resource> tempResources, List<Resource> newResources, Compatibility compatibility, string repo)
        {
            // If one of the lists is null, return
            if (tempResources == null || newResources == null)
            {
                return;
            }

            // Iterate over the new resources
            foreach (Resource resource in newResources)
            {
                // Try to get the first resource matching the name
                Resource found = tempResources.Where(x => x.Name == resource.Name).FirstOrDefault();

                // If the big list of resources contains this one, skip it
                if (found != null)
                {
                    Logger.Warn("Repository {0} already contains resource {1}, skipping...", found.Repo, found.Name);
                    continue;
                }

                // Save the repo and compatibility of the resource
                resource.Repo = repo;
                resource.Compatibility = compatibility;
                // And add the resource onto the big list
                tempResources.Add(resource);
            }
        }

        #endregion
    }
}
