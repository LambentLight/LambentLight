using LambentLight.API;
using LambentLight.Config;
using LambentLight.Managers.Builds;
using LambentLight.Managers.DataFolders;
using NLog;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LambentLight.Managers.Runtime
{
    public static class RuntimeManager
    {
        #region Private Fields

        /// <summary>
        /// The logger for our current class.
        /// </summary>
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();
        /// <summary>
        /// Every seccond where the players should be notified.
        /// </summary>
        private static readonly Dictionary<int, string> TimeChecks = new Dictionary<int, string>
        {
            { 3600, "minutes" }, // 60
            { 1800, "minutes" }, // 30
            { 900, "minutes" }, // 15
            { 600, "minutes" }, // 10
            { 300, "minutes" }, // 5
            { 240, "minutes" }, // 4
            { 180, "minutes" }, // 3
            { 120, "minutes" }, // 2
            { 60, "seconds" },
            { 30, "seconds" },
            { 15, "seconds" },
            { 10, "seconds" },
            { 5, "seconds" },
            { 4, "seconds" },
            { 3, "seconds" },
            { 2, "seconds" },
            { 1, "seconds" },
        };

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
        /// <summary>
        /// If the server is being stopped.
        /// </summary>
        public static bool IsShutdownInProgress { get; private set; } = false;
        /// <summary>
        /// If the LambentLight Bridge is available.
        /// </summary>
        public static bool IsBridgeAvailable { get; set; } = false;
        /// <summary>
        /// If the server is empty.
        /// </summary>
        public static bool IsServerEmpty { get; set; } = false;
        /// <summary>
        /// If the server is being closed, force it to stop.
        /// </summary>
        public static bool ForceServerShutdown { get; set; } = false;

        #endregion

        #region Basic Operations

        /// <summary>
        /// Starts the CFX server process with the specified Build and Data Folder.
        /// </summary>
        /// <param name="build">The CitizenFX Server Build.</param>
        /// <param name="folder">The folder with the configuration and resources.</param>
        public static async Task<bool> Start(Build build, DataFolder folder)
        {
            // If the server is already running, log it and return
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

            // Disable some values
            IsShutdownInProgress = false;
            IsBridgeAvailable = false;
            IsServerEmpty = false;
            ForceServerShutdown = false;

            // If the build folder is not there or the executable is missing
            if (!build.IsFolderPresent || !build.IsExecutablePresent)
            {
                // Try to download the CFX Build
                bool success = await build.Download();

                // If we failed, notify the user about it and return
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

            // Store the absolute path of the build and citizen folders
            string citizenPath = Path.Combine(build.Folder, "citizen");

            // Create a new server object
            Process process = new Process();
            // Set the executable of the server as the file to start
            process.StartInfo.FileName = Path.Combine(build.Folder, "FXServer.exe");
            // Set the path of the CFX Scripting stuff (metadata?)
            process.StartInfo.Arguments += $"+set citizen_dir \"{citizenPath}\" ";
            // Set the license from the configuration
            process.StartInfo.Arguments += $"+set sv_licenseKey {Program.Config.CFXToken} ";
            // If there is a Steam token, use it to make Steam Identifiers available
            process.StartInfo.Arguments += !string.IsNullOrWhiteSpace(Program.Config.SteamToken) ? "+set steam_webApiKey \"" + Program.Config.SteamToken + "\" " : "";
            // If the game is Red Dead Redemption 2, enable the respective flag
            process.StartInfo.Arguments += Program.Config.Game == Config.Game.RedDeadRedemption2 ? "+set gamename rdr3 " : "";
            // If the REST API is enabled, add the token and url
            process.StartInfo.Arguments += Program.Config.API.Enabled ? $"+set lambentlight_token \"{Program.Config.API.Token}\" " : "";
            process.StartInfo.Arguments += Program.Config.API.Enabled ? $"+set lambentlight_bind \"{Program.Config.API.BindTo}\" " : "";
            // And finally load the server configuration file
            process.StartInfo.Arguments += "+exec server.cfg";
            // Then, set the working directory as the server data folder
            process.StartInfo.WorkingDirectory = folder.Location;
            // Disable the usage of CMD to launch the process
            process.StartInfo.UseShellExecute = false;
            // Intercept STDOUT, STDIN and STDERR to the program
            process.StartInfo.RedirectStandardError = true;
            process.StartInfo.RedirectStandardInput = true;
            process.StartInfo.RedirectStandardOutput = true;
            // Don't create a command line window
            process.StartInfo.CreateNoWindow = true;
            // Redirect STDOUT and STDERR to NLog
            process.OutputDataReceived += (S, A) => { if (!string.IsNullOrWhiteSpace(A.Data)) { Logger.Info(A.Data); } };
            process.ErrorDataReceived += (S, A) => { if (!string.IsNullOrWhiteSpace(A.Data)) { Logger.Error(A.Data); } };
            // Start the process and start reading from STDOUT and STDERR
            process.Start();
            process.BeginOutputReadLine();
            process.BeginErrorReadLine();

            // Add the event to check if the server has crashed
            KeepRunning.Tick += KeepRunning_Tick;
            KeepRunning.Enabled = true;
            // If the user wants automated restarts every few hours/minutes/seconds, enable it
            if (Program.Config.AutoRestart.Cron)
            {
                RestartEvery.Interval = (int)Program.Config.AutoRestart.CronTime.TotalMilliseconds;
                RestartEvery.Tick += RestartEvery_Tick;
                RestartEvery.Enabled = true;
            }
            // If the user wants automated restarts at specific times of the day, also enable it
            if (Program.Config.AutoRestart.Daily)
            {
                RestartAt.Tick += RestartAt_Tick;
                RestartAt.Enabled = true;
            }

            // Save the information for the server that we started
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
            // If the server is already running
            if (IsServerRunning)
            {
                // Copy the server folder and build
                Build build = Build;
                DataFolder folder = Folder;
                // Stop the existing server
                await Stop();
                // And start a new one with the same build and data folder
                return await Start(build, folder);
            }
            // Otherwise, there is no need for a restart
            return false;
        }

        /// <summary>
        /// Stops the server if is running.
        /// </summary>
        public static async Task<bool> Stop(bool force = false)
        {
            // If there is no server running, notify the user and return
            if (!IsServerRunning)
            {
                Logger.Warn("The FiveM server is not running");
                return false;
            }

            // Save that there is a shutdown in progress and the server is not empty
            IsShutdownInProgress = true;
            IsServerEmpty = false;

            // If the server is not being stopped by force
            if (!force)
            {
                // If the LambentLight Bridge is available
                if (IsBridgeAvailable)
                {
                    // Send the command to start a shutdown
                    SendCommand("bridgeshutdown");
                    // And wait until the server is empty
                    await Wait();
                    // Once we got here, kick everyone just in case
                    SendCommand("bridgekickall");
                }
            }

            // Stop the events if they are running
            KeepRunning.Enabled = false;
            RestartEvery.Enabled = false;
            RestartAt.Enabled = false;

            // Terminate the process with any other ones left
            Process process = new Process();
            process.StartInfo.FileName = "taskkill.exe";
            process.StartInfo.Arguments = $"/pid {Process.Id} /f /t";
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
            // Disable the flags that we used
            IsShutdownInProgress = false;
            IsServerEmpty = false;
            // Remove the server information
            Process = null;
            Build = null;
            Folder = null;
            // Notify the user
            Program.Form.Invoke(new Action(() => Logger.Info("The FiveM server has been stopped")));
            // And return success
            return true;
        }

        /// <summary>
        /// Sends a command to the CFX server.
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

        #region Private Functions

        /// <summary>
        /// Waits the time specified in the config prior to stopping the server. 
        /// </summary>
        public static async Task Wait()
        {
            // Iterate over the wait time
            for (int i = Program.Config.WaitTime; i != 0; i--)
            {
                // If we are told to force a shutdown or the server is already empty, return
                if (ForceServerShutdown || IsServerEmpty)
                {
                    return;
                }

                // If the number is on the dictionary or matches the current wait time
                if (TimeChecks.ContainsKey(i) || i == Program.Config.WaitTime)
                {
                    // Generate the string that contains the readable format
                    string message = TimeChecks.ContainsKey(i) ? TimeChecks[i] : Program.Config.WaitMeasurement.ToString().ToLowerInvariant();
                    // If the message
                    int number = message == "minutes" ? (int)Math.Floor(i / 60f) : i;
                    // Notify everyone on the server and wait
                    SendCommand($"bridgenotify The server will close on {number} {message}.");
                }

                // And wait a second
                await Task.Delay(1000);
            }
        }

        #endregion

        #region Events

        /// <summary>
        /// Event that gets triggered to check if the server has crashed.
        /// </summary>
        private static async void KeepRunning_Tick(object sender, EventArgs args)
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
                    // Set the Server information to null
                    Process = null;
                    Build = null;
                    Folder = null;
                    // And finally log a message
                    Logger.Warn("The FiveM server has exited with a code {0}", Process.ExitCode);
                }
            }
        }

        /// <summary>
        /// Event that restarts the server every few hours/minutes/seconds.
        /// </summary>
        private static async void RestartEvery_Tick(object sender, EventArgs args)
        {
            // Just restart the server
            await Restart();
        }

        /// <summary>
        /// Event that restarts the server at specific times of the day.
        /// </summary>
        private static async void RestartAt_Tick(object sender, EventArgs args)
        {
            // If the hour, minutes and seconds matches, restart the server
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
