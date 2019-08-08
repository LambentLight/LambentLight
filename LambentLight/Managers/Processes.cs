using LambentLight.Properties;
using NLog;
using System;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LambentLight.Managers
{
    /// <summary>
    /// Class for storing some values for the launch of the server.
    /// </summary>
    public class RuntimeInformation
    {
        /// <summary>
        /// The FiveM build used to launch the process.
        /// </summary>
        public Build Build { get; set; }
        /// <summary>
        /// The Data Folder with the server information.
        /// </summary>
        public DataFolder Folder { get; set; }
        /// <summary>
        /// The server process.
        /// </summary>
        public Process Process { get; set; }
    }

    /// <summary>
    /// Manages the start, stop and restart of the CFX server.
    /// </summary>
    public static class ProcessManager
    {
        /// <summary>
        /// The logger for our current class.
        /// </summary>
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();
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
        public static Timer AutoRestart = new Timer();
        /// <summary>
        /// Timer that restarts the server every few hours/minutes/seconds.
        /// </summary>
        public static Timer RestartEvery = new Timer();
        /// <summary>
        /// Timer that restarts the server at specific times of the day.
        /// </summary>
        public static Timer RestartAt = new Timer();

        private static RuntimeInformation GenerateClass(Build build, DataFolder data)
        {
            // Store the absolute path of the folder
            string AbsPath = Path.GetFullPath(build.Folder);
            // Create a new Server object
            RuntimeInformation NewServer = new RuntimeInformation();
            // Create a new server object and set the correct properties
            NewServer.Process = new Process();
            NewServer.Process.StartInfo.FileName = Path.Combine(AbsPath, "FXServer.exe");
            NewServer.Process.StartInfo.Arguments = string.Format("+set citizen_dir \"{0}\" +set sv_licenseKey {1} +exec server.cfg", Path.Combine(AbsPath, "citizen"), Settings.Default.License);
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
            if (string.IsNullOrWhiteSpace(Settings.Default.License))
            {
                Logger.Error("There is no valid FiveM license set up!");
                return false;
            }

            // If the build is not available
            if (!build.IsAvailable)
            {
                await BuildManager.Download(build);
            }

            // Format the path for the cache folder
            string Cache = Path.Combine(data.Location, "cache");
            // If there is a cache folder and the user wants them gone, remove it
            if (Settings.Default.ClearCache && Directory.Exists(Cache))
            {
                Directory.Delete(Cache, true);
                Logger.Info("The cache folder was present on '{0}'", data.Name);
            }
            // Create and save the new class that contains the information that we need
            Server = GenerateClass(build, data);


            // Add the event to check if the server has exited
            AutoRestart.Interval = 100;
            AutoRestart.Tick += RestartOnBadExitEvent;
            AutoRestart.Enabled = true;
            // If the user wants automated restarts every few hours/minutes/seconds
            if (Settings.Default.RestartEvery)
            {
                RestartEvery.Interval = (int)Settings.Default.RestartEveryTime.TotalMilliseconds;
                RestartEvery.Tick += RestartEveryEvent;
                RestartEvery.Enabled = true;
            }
            // If the user wants automated restarts at specific times of the day
            if (Settings.Default.RestartAt)
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
        public static void Restart()
        {
            // If the server is running
            if (Server != null && Server.Process.IsRunning())
            {
                // Create a new instance of the server
                RuntimeInformation NewServer = GenerateClass(Server.Build, Server.Folder);
                // Stop the existing server
                Stop();
                // Set the new server
                Server = NewServer;
                // And start it
                Server.Process.Start();
            }
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
            }

            // If the server process is running
            if (Server.Process.IsRunning())
            {
                // Kill it
                Server.Process.Kill();
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
                AutoRestart.Enabled = false;
                RestartEvery.Enabled = false;
                RestartAt.Enabled = false;
                // Remove the server information
                Server = null;
                // And notify the user
                Logger.Info("The FiveM server has been stopped");
            }
        }

        /// <summary>
        /// Event that gets triggered to check if the server has crashed.
        /// </summary>
        private static void RestartOnBadExitEvent(object sender, EventArgs args)
        {
            // If the server exists, is not running and has an exit code of not zero
            if (Server != null && !Server.Process.IsRunning() && Server.Process.ExitCode != 0)
            {
                // If the user wants to restart
                if (Settings.Default.AutoRestart)
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
                    AutoRestart.Enabled = false;
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
        private static void RestartEveryEvent(object sender, EventArgs args)
        {
            // Just restart the server
            Restart();
        }

        /// <summary>
        /// Event that restarts the server at specific times of the day.
        /// </summary>
        private static void RestartAtEvent(object sender, EventArgs args)
        {
            // If the hour, minute and second matches, restart the server
            if (DateTime.Now.Hour == Settings.Default.RestartAtTime.Hours &&
                DateTime.Now.Minute == Settings.Default.RestartAtTime.Minutes &&
                DateTime.Now.Second == Settings.Default.RestartAtTime.Seconds)
            {
                Restart();
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
