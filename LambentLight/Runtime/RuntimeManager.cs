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
        /// The process of the current CitizenFX Server.
        /// </summary>
        public static Process Process { get; set; } = null;
        /// <summary>
        /// The CFX build used to launch the process.
        /// </summary>
        public static Build Build { get; set; } = null;
        /// <summary>
        /// The Data Folder with the server information.
        /// </summary>
        public static DataFolder Folder { get; set; } = null;
        /// <summary>
        /// If the FiveM server is running or not.
        /// </summary>
        public static bool IsServerRunning => Process != null && Process.IsRunning();
        /// <summary>
        /// Timer that keeps the server running even after crashes.
        /// </summary>
        public static Timer KeepRunning { get; } = new Timer() { Interval = 100 };
        /// <summary>
        /// Timer that restarts the server every few hours/minutes/seconds.
        /// </summary>
        public static Timer RestartEvery { get; } = new Timer();
        /// <summary>
        /// Timer that restarts the server at specific times of the day.
        /// </summary>
        public static Timer RestartAt { get; } = new Timer() { Interval = 1000 };

        #endregion

        #region Basic Operations

        /// <summary>
        /// Starts the CFX server process.
        /// </summary>
        /// <param name="build">The build to use.</param>
        /// <param name="data">The folder to use the data from.</param>
        public static async Task<bool> Start(Build build, DataFolder folder)
        {
            // If there is a server instance running, log it and return
            if (IsServerRunning)
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
            if (!build.IsFolderPresent || !build.IsExecutablePresent)
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
            string cachePath = Path.Combine(folder.Location, "cache");
            // If there is a cache folder and the user wants them gone, remove it
            if (Program.Config.ClearCache && Directory.Exists(cachePath))
            {
                Directory.Delete(cachePath, true);
                Logger.Info("The cache folder was present on '{0}'", folder.Name);
            }

            // Store the absolute path of the folder
            string absolutePath = Path.GetFullPath(build.Folder);
            string citizenPath = Path.Combine(absolutePath, "citizen");

            // Create a new server object and set the correct properties
            Process process = new Process();
            process.StartInfo.FileName = Path.Combine(absolutePath, "FXServer.exe");
            process.StartInfo.Arguments += $"+set citizen_dir \"{citizenPath}\" ";
            process.StartInfo.Arguments += $"+set sv_licenseKey {Program.Config.CFXToken} ";
            process.StartInfo.Arguments += !string.IsNullOrWhiteSpace(Program.Config.SteamToken) ? "+set steam_webApiKey \"" + Program.Config.SteamToken + "\" " : "";
            process.StartInfo.Arguments += Program.Config.Game == Config.Game.RedDeadRedemption2 ? "+set gamename rdr3 " : "";
            process.StartInfo.Arguments += "+exec server.cfg";
            process.StartInfo.WorkingDirectory = folder.Absolute;
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.RedirectStandardError = true;
            process.StartInfo.RedirectStandardInput = true;
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.CreateNoWindow = true;
            process.OutputDataReceived += (S, A) => { if (!string.IsNullOrWhiteSpace(A.Data)) { Logger.Info(A.Data); } };
            process.ErrorDataReceived += (S, A) => { if (!string.IsNullOrWhiteSpace(A.Data)) { Logger.Error(A.Data); } };
            process.Start();
            process.BeginOutputReadLine();
            process.BeginErrorReadLine();

            // Add the event to check if the server has exited
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
                RestartAt.Tick += RestartAtEvent;
                RestartAt.Enabled = true;
            }

            // Save the current information
            Process = process;
            Build = build;
            Folder = folder;

            // And return success
            return true;
        }

        /// <summary>
        /// Restarts the server if is running.
        /// </summary>
        public static async Task<bool> Restart()
        {
            // If the server is running
            if (IsServerRunning)
            {
                // Get the server folder and build
                Build build = Build;
                DataFolder folder = Folder;
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
            if (!IsServerRunning)
            {
                Logger.Warn("The FiveM server is not running");
                return;
            }

            // Stop the events if they are running
            KeepRunning.Enabled = false;
            RestartEvery.Enabled = false;
            RestartAt.Enabled = false;

            // Kill it
            Process.Kill();
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
                Process.CancelOutputRead();
                Process.CancelErrorRead();
            }
            // If they are not available
            catch (InvalidOperationException)
            {
                // Do nothing
            }
            // Remove the server information
            Process = null;
            Build = null;
            Folder = null;
            // And notify the user
            Logger.Info("The FiveM server has been stopped");
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
            Process.StandardInput.WriteLine(command);
            Process.StandardInput.Flush();
        }

        #endregion

        #region Events

        /// <summary>
        /// Event that gets triggered to check if the server has crashed.
        /// </summary>
        private static async void RestartOnBadExitEvent(object sender, EventArgs args)
        {
            // If the server exists, is not running and has an exit code of not zero
            if (Process != null && !Process.IsRunning() && Process.ExitCode != 0)
            {
                // If the user wants to restart
                if (Program.Config.RestartOnCrash)
                {
                    // Log a message
                    Logger.Warn("Server exited with a code {0}, restarting...", Process.ExitCode);
                    // And start the server again
                    await Restart();
                }
                // Otherwise
                else
                {
                    // Disable this event
                    KeepRunning.Enabled = false;
                    // Unlock the controls
                    Program.Form.Locked = false;
                    // And log a message
                    Logger.Warn("The FiveM server has exited with a code {0}", Process.ExitCode);
                    // Set the Server information to null
                    Process = null;
                    Build = null;
                    Folder = null;
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
        /// Checks if the process is running.
        /// </summary>
        /// <returns>true if the process is running, false otherwise.</returns>
        private static bool IsRunning(this Process process)
        {
            try
            {
                Process.GetProcessById(process.Id);
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
