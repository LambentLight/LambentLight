using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LambentLight
{
    /// <summary>
    /// The current status of the server executable.
    /// </summary>
    public enum ServerStatus
    {
        Stopped = -1,
        Running = 0
    }

    /// <summary>
    /// Manages the start, stop and restart of the CFX server.
    /// </summary>
    public static class ServerManager
    {
        /// <summary>
        /// The server process that is currently running.
        /// </summary>
        public static Process Server { get; private set; } = null;

        /// <summary>
        /// Starts the CFX server process.
        /// </summary>
        /// <param name="build">The build to use.</param>
        /// <param name="data">The folder to use the data from.</param>
        public static async Task Start(Build build, DataFolder data)
        {
            // If there is a server instance running, return
            if (Server != null)
            {
                return;
            }

            // If the build is not available
            if (!build.IsAvailable)
            {
                await BuildManager.Download(build);
            }
        }

        /// <summary>
        /// Stops the server if is running.
        /// </summary>
        public static async Task Stop()
        {

        }
    }
}
