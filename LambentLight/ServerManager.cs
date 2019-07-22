using NLog;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
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
        /// The logger for our current class.
        /// </summary>
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();
        /// <summary>
        /// The server process that is currently running.
        /// </summary>
        public static Process Server { get; private set; } = null;

        /// <summary>
        /// Starts the CFX server process.
        /// </summary>
        /// <param name="build">The build to use.</param>
        /// <param name="data">The folder to use the data from.</param>
        public static async Task<bool> Start(Build build, DataFolder data)
        {
            // If there is a server instance running, log it and return
            if (Server != null)
            {
                Logger.Warn("There is already a server running");
                return false;
            }

            // If there is no license set up, notify it and return
            if (string.IsNullOrWhiteSpace(Properties.Settings.Default.License))
            {
                Logger.Error("There is no valid FiveM license set up!");
                return false;
            }

            // If the build is not available
            if (!build.IsAvailable)
            {
                await BuildManager.Download(build);
            }

            // Store the absolute path of the folder
            string AbsPath = Path.GetFullPath(build.Folder);
            // Create a new server object and set the correct properties
            Server = new Process();
            Server.StartInfo.FileName = Path.Combine(AbsPath, "FXServer.exe");
            Server.StartInfo.Arguments = string.Format("+set citizen_dir \"{0}\" +set sv_licenseKey {1} +exec server.cfg", Path.Combine(AbsPath, "citizen"), Properties.Settings.Default.License);
            Server.StartInfo.WorkingDirectory = data.Absolute;
            Server.StartInfo.UseShellExecute = false;
            Server.StartInfo.RedirectStandardError = true;
            Server.StartInfo.RedirectStandardInput = true;
            Server.StartInfo.RedirectStandardOutput = true;
            Server.StartInfo.CreateNoWindow = true;
            Server.OutputDataReceived += (S, A) => { if (!string.IsNullOrWhiteSpace(A.Data)) Logger.Info(A.Data); } ;
            Server.Exited += ProcessExited;
            Server.Start();
            Server.BeginOutputReadLine();
            Server.BeginErrorReadLine();

            return true;
        }

        private static void ProcessExited(object sender, EventArgs args)
        {
            // If the code is not zero, start it again
            if (Server.ExitCode != 0)
            {
                Server.Start();
                Server.BeginOutputReadLine();
                Server.BeginErrorReadLine();
            }
        }

        /// <summary>
        /// Stops the server if is running.
        /// </summary>
        public static async Task<bool> Stop()
        {
            // If there is no server running, notify the user and return
            if (Server == null)
            {
                Logger.Warn("The FiveM server is not running");
                return false;
            }

        }

        /// <summary>
        /// Cheks if the current process is running.
        /// </summary>
        /// <returns>true if the process is running, false otherwise.</returns>
        public static bool IsRunning(this Process Check)
        {
            try
            {
                Process.GetProcessById(Check.Id);
            }
            catch (ArgumentException)
            {
                return false;
            }
            catch (InvalidOperationException)
            {
                return false;
            }
            return true;
        }
    }
}
