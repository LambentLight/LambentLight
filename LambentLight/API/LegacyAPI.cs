using LambentLight.Managers.Runtime;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LambentLight.API
{
    /// <summary>
    /// Manager for the CitizenFX REST API.
    /// </summary>
    public static class LegacyAPI
    {
        /// <summary>
        /// Gets the list of players in the server.
        /// </summary>
        public static async Task<List<CitizenPlayer>> GetPlayers()
        {
            // If the server is not running, return
            if (!RuntimeManager.IsServerRunning)
            {
                return null;
            }

            // Get the port of the server
            ushort port = RuntimeManager.Folder.WebPort;

            // If the port of the server is zero, return
            if (port == 0)
            {
                return null;
            }

            // At this point, return the list of players
            return await Downloader.DownloadJSONAsync<List<CitizenPlayer>>($"http://127.0.0.1:{port}/players.json");
        }

        /// <summary>
        /// The information of the current CitizenFX server.
        /// </summary>
        public static async Task<CitizenResponse> GetInfo()
        {
            // If the server is not running, return
            if (!RuntimeManager.IsServerRunning)
            {
                return null;
            }

            // Get the port of the server
            ushort port = RuntimeManager.Folder.WebPort;

            // If the port of the server is zero, return
            if (port == 0)
            {
                return null;
            }

            // At this point, return the list of players
            return await Downloader.DownloadJSONAsync<CitizenResponse>($"http://127.0.0.1:{port}/info.json");
        }

        /// <summary>
        /// If the LambentLight bridge is running on the server.
        /// </summary>
        public static async Task<bool> IsBridgeRunning()
        {
            // Try to get the server information
            CitizenResponse response = await GetInfo();

            // If the response is empty, return
            if (response == null)
            {
                return false;
            }

            // Otherwise, do the correct checks
            return RuntimeManager.IsServerRunning && response.Resources.Contains("lambentlight");
        }
    }
}
