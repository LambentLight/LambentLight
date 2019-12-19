using LambentLight.Managers;
using NLog;
using System;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LambentLight.Runtime
{
    public static class RuntimeManager
    {
        #region Private Fields

        /// <summary>
        /// The logger for our current class.
        /// </summary>
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        #endregion

        #region Public Properties

        /// <summary>
        /// The server process that is currently running.
        /// </summary>
        public static RuntimeInformation Server { get; private set; } = null;
        /// <summary>
        /// If the FiveM server is running or not.
        /// </summary>
        public static bool IsServerRunning => Server != null && Server.Process.IsRunning();
        /// <summary>
        /// Timer that keeps the server running even after crashes.
        /// </summary>
        public static Timer KeepRunning { get; } = new Timer();
        /// <summary>
        /// Timer that restarts the server every few hours/minutes/seconds.
        /// </summary>
        public static Timer RestartEvery { get; } = new Timer();
        /// <summary>
        /// Timer that restarts the server at specific times of the day.
        /// </summary>
        public static Timer RestartAt { get; } = new Timer();

        #endregion

        #region Basic Operations

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
            if (string.IsNullOrWhiteSpace(Program.Config.CFXToken))
            {
                Logger.Error("There is no valid FiveM license set up!");
                return false;
            }

            // If the build folder is not there or the executable is missing
            if (!build.IsFolderPresent && !build.IsExecutablePresent)
            {
                // Try to download the build the build
                bool success = await BuildManager.Download(build);

                // If we failed, notify the user that is not possible and return
                if (!success)
                {
                    Logger.Error("The server cannot be started because the selected build does not works.");
                    return false;
                }
            }

            // Format the path for the cache folder
            string Cache = Path.Combine(data.Location, "cache");
            // If there is a cache folder and the user wants them gone, remove it
            if (Program.Config.ClearCache && Directory.Exists(Cache))
            {
                Directory.Delete(Cache, true);
                Logger.Info("The cache folder was present on '{0}'", data.Name);
            }
            // Create and save the new class that contains the information that we need
            Server = GenerateClass(build, data);
            // If there was an error while launching the server, just return
            if (Server == null)
            {
                return false;
            }

            // Add the event to check if the server has exited
            KeepRunning.Interval = 100;
            KeepRunning.Tick += RestartOnBadExitEvent;
            KeepRunning.Enabled = true;
            // If the user wants automated restarts every few hours/minutes/seconds
            if (Program.Config.AutoRestart.Cron)
            {
                RestartEvery.Interval = (int)Program.Config.AutoRestart.CronTime.TotalMilliseconds;
                RestartEvery.Tick += RestartEveryEvent;
                RestartEvery.Enabled = true;
            }
            // If the user wants automated restarts at specific times of the day
            if (Program.Config.AutoRestart.Daily)
            {
                RestartAt.Interval = 1000;
                RestartAt.Tick += RestartAtEvent;
                RestartAt.Enabled = true;
            }

            return true;
        }

        /// <summary>
        /// Restarts the server if is running.
        /// </summary>
        public static async Task<bool> Restart()
        {
            // If the server is running
            if (Server != null && Server.Process.IsRunning())
            {
                // Get the server folder and build
                Build build = Server.Build;
                DataFolder folder = Server.Folder;
                // Stop the existing server
                Stop();
                // Set the new server
                return await Start(build, folder);
            }
            // Otherwise, there is no need for a restart
            return false;
        }

        /// <summary>
        /// Stops the server if is running.
        /// </summary>
        public static void Stop()
        {
            // If there is no server running, notify the user and return
            if (Server == null)
            {
                Logger.Warn("The FiveM server is not running");
                return;
            }

            // If the server process is running
            if (Server.Process.IsRunning())
            {
                // Kill it
                Server.Process.Kill();
                // And terminate any orphan processes just in case
                Process process = new Process();
                process.StartInfo.FileName = "taskkill.exe";
                process.StartInfo.Arguments = "/f /im FXServer.exe";
                process.StartInfo.UseShellExecute = false;
                process.StartInfo.CreateNoWindow = true;
                process.Start();
                process.WaitForExit();

                // Try to cancel the STDOUT and STDERR background reads
                try
                {
                    Server.Process.CancelOutputRead();
                    Server.Process.CancelErrorRead();
                }
                // If they are not available
                catch (InvalidOperationException)
                {
                    // Do nothing
                }
                // Disable the auto restarts
                KeepRunning.Enabled = false;
                RestartEvery.Enabled = false;
                RestartAt.Enabled = false;
                // Remove the server information
                Server = null;
                // And notify the user
                Logger.Info("The FiveM server has been stopped");
            }
        }
        /// <summary>
        /// Sends a command to the FiveM server.
        /// </summary>
        /// <param name="command">The command to send.</param>
        public static void SendCommand(string command)
        {
            // If the server is not running, return
            if (!IsServerRunning)
            {
                return;
            }

            // Write the command and flush it
            Server.Process.StandardInput.WriteLine(command);
            Server.Process.StandardInput.Flush();
        }

        #endregion

        #region Tools

        private static RuntimeInformation GenerateClass(Build build, DataFolder data)
        {
            // Store the absolute path of the folder
            string AbsPath = Path.GetFullPath(build.Folder);
            string citizenPath = Path.Combine(AbsPath, "citizen");

            // If the file being part of the build does not exists
            if (!File.Exists(Path.Combine(AbsPath, "FXServer.exe")))
            {
                Logger.Error($"The installed build {build.ID} does not contains the server executable.");
                return null;
            }

            // Create a new Server object
            RuntimeInformation NewServer = new RuntimeInformation();
            // Create a new server object and set the correct properties
            NewServer.Process = new Process();
            NewServer.Process.StartInfo.FileName = Path.Combine(AbsPath, "FXServer.exe");
            NewServer.Process.StartInfo.Arguments += $"+set citizen_dir \"{citizenPath}\" ";
            NewServer.Process.StartInfo.Arguments += $"+set sv_licenseKey {Program.Config.CFXToken} ";
            NewServer.Process.StartInfo.Arguments += !string.IsNullOrWhiteSpace(Program.Config.SteamToken) ? "+set steam_webApiKey \"" + Program.Config.SteamToken + "\" " : "";
            NewServer.Process.StartInfo.Arguments += Program.Config.Game == Config.Game.RedDeadRedemption2 ? "+set gamename rdr3 " : "";
            NewServer.Process.StartInfo.Arguments += "+exec server.cfg";
            NewServer.Process.StartInfo.WorkingDirectory = data.Absolute;
            NewServer.Process.StartInfo.UseShellExecute = false;
            NewServer.Process.StartInfo.RedirectStandardError = true;
            NewServer.Process.StartInfo.RedirectStandardInput = true;
            NewServer.Process.StartInfo.RedirectStandardOutput = true;
            NewServer.Process.StartInfo.CreateNoWindow = true;
            NewServer.Process.OutputDataReceived += (S, A) => { if (!string.IsNullOrWhiteSpace(A.Data)) { Logger.Info(A.Data); } };
            NewServer.Process.ErrorDataReceived += (S, A) => { if (!string.IsNullOrWhiteSpace(A.Data)) { Logger.Error(A.Data); } };
            NewServer.Process.Start();
            NewServer.Process.BeginOutputReadLine();
            NewServer.Process.BeginErrorReadLine();
            // Save the build and data folder
            NewServer.Build = build;
            NewServer.Folder = data;
            // Finally, return the new class
            return NewServer;
        }

        #endregion

        #region Events

        /// <summary>
        /// Event that gets triggered to check if the server has crashed.
        /// </summary>
        private static void RestartOnBadExitEvent(object sender, EventArgs args)
        {
            // If the server exists, is not running and has an exit code of not zero
            if (Server != null && !Server.Process.IsRunning() && Server.Process.ExitCode != 0)
            {
                // If the user wants to restart
                if (Program.Config.RestartOnCrash)
                {
                    // Log a message
                    Logger.Warn("Server exited with a code {0}, restarting...", Server.Process.ExitCode);
                    // And start the server again
                    Server = GenerateClass(Server.Build, Server.Folder);
                    Server.Process.Start();
                }
                // Otherwise
                else
                {
                    // Disable this event
                    KeepRunning.Enabled = false;
                    // Unlock the controls
                    Program.Form.Locked = false;
                    // And log a message
                    Logger.Warn("The FiveM server has exited with a code {0}", Server.Process.ExitCode);
                    // Set the Server information to null
                    Server = null;
                }
            }
        }

        /// <summary>
        /// Event that restarts the server every few hours/minutes/seconds.
        /// </summary>
        private static async void RestartEveryEvent(object sender, EventArgs args)
        {
            // Just restart the server
            await Restart();
        }

        /// <summary>
        /// Event that restarts the server at specific times of the day.
        /// </summary>
        private static async void RestartAtEvent(object sender, EventArgs args)
        {
            // If the hour, minute and second matches, restart the server
            if (DateTime.Now.Hour == Program.Config.AutoRestart.DailyTime.Hours &&
                DateTime.Now.Minute == Program.Config.AutoRestart.DailyTime.Minutes &&
                DateTime.Now.Second == Program.Config.AutoRestart.DailyTime.Seconds)
            {
                await Restart();
            }
        }

        #endregion

        #region Extensions

        /// <summary>
        /// Cheks if the current process is running.
        /// </summary>
        /// <returns>true if the process is running, false otherwise.</returns>
        private static bool IsRunning(this Process Check)
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

        #endregion
    }
}
