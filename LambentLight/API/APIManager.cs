using LambentLight.Managers.Runtime;
using System.Collections.Generic;

namespace LambentLight.API
{
    /// <summary>
    /// Manager for the CitizenFX REST API.
    /// </summary>
    public static class APIManager
    {
        /// <summary>
        /// The list of players in the server.
        /// </summary>
        public static List<CitizenPlayer> Players => Downloader.DownloadJSON<List<CitizenPlayer>>("http://127.0.0.1:30120/players.json");
        /// <summary>
        /// The information of the current CitizenFX server.
        /// </summary>
        public static CitizenResponse Info => Downloader.DownloadJSON<CitizenResponse>("http://127.0.0.1:30120/info.json");
        /// <summary>
        /// If the LambentLight bridge is running on the server.
        /// </summary>
        public static bool IsBridgeRunning => RuntimeManager.IsServerRunning && Info.Resources.Contains("lambentlight");
    }
}
