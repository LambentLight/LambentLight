using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ServerManager
{
    public partial class Landing : Form
    {
        /// <summary>
        /// Path of the current executable.
        /// </summary>
        private static string MainFolder = new Uri(Path.GetDirectoryName(Assembly.GetExecutingAssembly().CodeBase)).LocalPath;
        /// <summary>
        /// Path of the Server Builds data.
        /// </summary>
        private static string Builds = Path.Combine(MainFolder, "Builds");
        /// <summary>
        /// Path of the User Data folder.
        /// </summary>
        private static string Data = Path.Combine(MainFolder, "Data");
        /// <summary>
        /// The place where the build should be downloaded.
        /// </summary>
        private static string DownloadUrl = "https://runtime.fivem.net/artifacts/fivem/build_server_windows/master/{0}/server.zip";
        /// <summary>
        /// Information for the server process.
        /// </summary>
        private static Process ServerProcess = new Process();
        /// <summary>
        /// The current server status.
        /// </summary>
        private static Status ServerStatus = Status.Stopped;
        /// <summary>
        /// Links on the builds page that should not be considered as builds.
        /// </summary>
        private static List<string> InvalidBuilds = new List<string>
        {
            "Parent directory",
            "revoked",
            "Date",
            "File Size",
            "File Name"
        };
        /// <summary>
        /// If the last scheduled restart was completed.
        /// </summary>
        private bool LastRestart = false;

        public Landing()
        {
            // Check if the folder "Builds" exists
            if (!Directory.Exists(Builds))
            {
                // If not, create it
                Directory.CreateDirectory(Builds);
            }
            // Check if the folder "Data" exists
            if (!Directory.Exists(Data))
            {
                // If not, create it
                Directory.CreateDirectory(Data);
            }
            // Initialize the UI
            InitializeComponent();
        }

        private void LimitAvailableControls(bool Enable)
        {
            StartServer.Enabled = !Enable;
            StopServer.Enabled = Enable;
            EditServerConfig.Enabled = !Enable;
            OpenSettings.Enabled = !Enable;

            BuildList.Enabled = !Enable;
            DataList.Enabled = !Enable;
            RefreshBuilds.Enabled = !Enable;
            RefreshData.Enabled = !Enable;
        }

        private void RefreshServerBuilds()
        {
            // Lock both of the selectors
            LimitAvailableControls(true);
            // Clear the list of items
            BuildList.Items.Clear();
            // Create a new web parser
            HtmlWeb Web = new HtmlWeb();
            // Get the document from the FiveM build list
            HtmlAgilityPack.HtmlDocument Doc = Web.Load("https://runtime.fivem.net/artifacts/fivem/build_server_windows/master/");
            // Create a list of versions from the links without the "/" at the end
            List<string> Versions = Doc.DocumentNode.SelectNodes("//a").Select(X => X.InnerText.TrimEnd('/')).ToList();
            
            // Iterate over the versions that we got and ignore those that are not builds or have a "Non-breaking space"
            foreach (string Version in Versions.Where(X => !InvalidBuilds.Contains(X) && !X.Contains("&nbsp")))
            {
                // And add that version into the ComboBox
                BuildList.Items.Add(Version);
            }
            
            // Finally, unlock the selectors and restore the last build used
            LimitAvailableControls(false);
            RestoreLastBuildUsed();
        }

        private void RefreshServerData()
        {
            // Lock both of the selectors
            LimitAvailableControls(true);
            // Clear the list of items
            DataList.Items.Clear();
            // Iterate over the subdirectories in the "Data" folder
            foreach (string Dir in Directory.GetDirectories(Data))
            {
                // If there is a "server.cfg" on the folder, count it
                if (File.Exists(Path.Combine(Dir, "server.cfg")))
                {
                    // Generate the URI/URL file
                    string Directory = new DirectoryInfo(Dir).Name;
                    // And add it into the list of data folders
                    DataList.Items.Add(Directory);
                }
            }

            // Finally, unlock the selectors and the last server data used
            LimitAvailableControls(false);
            RestoreLastDataUsed();
        }

        private void RestoreLastBuildUsed()
        {
            // If the last used build is not null or a white space and the item exists
            if (!string.IsNullOrWhiteSpace(Properties.Settings.Default.LastBuild) && BuildList.FindStringExact(Properties.Settings.Default.LastBuild) != -1)
            {
                // Get the number of the index and set it as selected
                BuildList.SelectedIndex = BuildList.FindStringExact(Properties.Settings.Default.LastBuild);
            }
        }

        private void RestoreLastDataUsed()
        {
            // If the last used data is not null or a white space and the item exists
            if (!string.IsNullOrWhiteSpace(Properties.Settings.Default.LastData) && DataList.FindStringExact(Properties.Settings.Default.LastData) != -1)
            {
                // Get the number of the index and set it as selected
                DataList.SelectedIndex = DataList.FindStringExact(Properties.Settings.Default.LastData);
            }
        }

        private void StartServerNow()
        {
            // Get the build and data folders
            string BuildFolder = Path.Combine(Builds, BuildList.SelectedItem.ToString());
            string DataFolder = Path.Combine(Data, DataList.SelectedItem.ToString());
            // Lock both of the selectors
            LimitAvailableControls(true);
            // Set the parameters for launching the server process and capture the output
            ServerProcess = new Process();
            ServerProcess.StartInfo.FileName = Path.Combine(BuildFolder, "FXServer.exe");
            ServerProcess.StartInfo.Arguments = $"+set citizen_dir \"{BuildFolder}\\citizen\" +set sv_licenseKey {Properties.Settings.Default.License} +exec server.cfg";
            ServerProcess.StartInfo.WorkingDirectory = DataFolder;
            ServerProcess.StartInfo.UseShellExecute = false;
            ServerProcess.StartInfo.RedirectStandardError = true;
            ServerProcess.StartInfo.RedirectStandardInput = true;
            ServerProcess.StartInfo.RedirectStandardOutput = true;
            ServerProcess.StartInfo.CreateNoWindow = true;
            ServerProcess.OutputDataReceived += (S, A) => ServerOutput.Invoke(new Action(() => { if (!string.IsNullOrWhiteSpace(A.Data)) ServerOutput.AppendLine(A.Data); }));
            ServerProcess.Start();
            ServerProcess.BeginOutputReadLine();
            ServerProcess.BeginErrorReadLine();
            ServerStatus = Status.Running;

            // Try to get the RCON password
            string Config = File.ReadAllText(Path.Combine(DataFolder, "server.cfg"));
            Match RCON = Expressions.RCONPassword.Match(Config);
            Match Port = Expressions.PortUDP.Match(Config);
            
            // If both matches are successful
            if (RCON.Success && Port.Success)
            {
                // Do the work
            }
        }

        private bool StopServerNow()
        {
            // Set the status as stopped
            ServerStatus = Status.Stopped;
            // Unlock the selectors
            LimitAvailableControls(false);
            // If the server process is running, kill it
            if (ServerProcess.IsRunning())
            {
                ServerProcess.Kill();
                ServerProcess.CancelOutputRead();
                ServerProcess.CancelErrorRead();
                return true;
            }
            // At this point, is not running
            else
            {
                return false;
            }
        }

        private void OpenSettings_Click(object sender, EventArgs e)
        {
            // Create an instance of the Settings window
            Settings SettingsWindow = new Settings();
            // Show it as a dialog (so the user is unable to launch a server)
            SettingsWindow.ShowDialog();
            // Once we return, set the interval time if the type of restart is zero
            if (Properties.Settings.Default.ScheduledMode == 0)
            {
                ScheduledRestart.Interval = (int)Properties.Settings.Default.ScheduledTime.TotalMilliseconds;
            }
        }

        private void RefreshBuilds_Click(object sender, EventArgs e)
        {
            // Self explanatory
            RefreshServerBuilds();
        }

        private void RefreshData_Click(object sender, EventArgs e)
        {
            // Self explanatory
            RefreshServerData();
        }

        private void BuildList_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Store the last used server build if is not empty or a whitespace
            if (!string.IsNullOrWhiteSpace(BuildList.SelectedItem.ToString()))
            {
                Properties.Settings.Default.LastBuild = BuildList.SelectedItem.ToString();
            }
        }

        private void DataList_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Store the last used server build if is not empty or a whitespace
            if (!string.IsNullOrWhiteSpace(DataList.SelectedItem.ToString()))
            {
                Properties.Settings.Default.LastData = DataList.SelectedItem.ToString();
            }
        }

        private async void StartServer_Click(object sender, EventArgs e)
        {
            // Check that the user has entered a FiveM license key
            if (string.IsNullOrWhiteSpace(Properties.Settings.Default.License))
            {
                ServerOutput.AppendLine("To start a server, go to the Settings menu and add a FiveM license.");
                return;
            }

            // And also check if there is no build selected, return
            if (BuildList.SelectedIndex == -1 || DataList.SelectedIndex == -1)
            {
                ServerOutput.AppendLine("You need to select a Build and a Server Data.");
                return;
            }

            // Store the path that we are going to use with the download origin and destination
            string BuildFolder = Path.Combine(Builds, BuildList.SelectedItem.ToString());
            string DataFolder = Path.Combine(Data, DataList.SelectedItem.ToString());
            Uri DownloadOrigin = new Uri(string.Format(DownloadUrl, BuildList.SelectedItem.ToString()));
            string DownloadLocation = Path.Combine(Builds, BuildList.SelectedItem.ToString() + ".zip");

            // Check if the FiveM build exists locally
            if (!Directory.Exists(BuildFolder))
            {
                // Looks like there is no build, notify the user
                ServerOutput.AppendLine("The build was not found locally, attempting a download...");
                // And download the file
                ServerOutput.AppendLine("The download for the file has started, check the Progress Bar.");
                await DownloadClient.DownloadFileTaskAsync(DownloadOrigin, DownloadLocation);
                // Wait until the file has been downloaded
                while (DownloadClient.IsBusy)
                {
                    await Task.Delay(0);
                }
                // Sanity check: Check if the folder already exists and delete it recursively
                if (Directory.Exists(BuildFolder))
                {
                    Directory.Delete(BuildFolder, true);
                }
                // Create the folder for the current build
                Directory.CreateDirectory(BuildFolder);
                // Notify the user about the extraction
                ServerOutput.AppendLine("The file was downloaded, extracting the content...");
                // And extract the files
                await Task.Run(() => ZipFile.ExtractToDirectory(DownloadLocation, BuildFolder));
                ServerOutput.AppendLine("The file has been extracted, no problems found.");
                // Finally, restore the progress bar status
                GeneralProgress.Value = 0;
            }

            // If the user wants to delete the cache folder and is there
            if (Directory.Exists(Path.Combine(DataFolder, "cache")) && Properties.Settings.Default.ClearCache)
            {
                // Remove it and notify the user
                Directory.Delete(Path.Combine(DataFolder, "cache"), true);
                ServerOutput.AppendLine("The 'cache' folder was present and it was removed.");
            }

            StartServerNow();
        }

        private void DownloadClient_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            // Calculate the percentage of the download
            int Percentage = (int)((float)e.BytesReceived / e.TotalBytesToReceive * 100f);
            // Make a sanity check to make sure about the download progress
            if (Percentage >= GeneralProgress.Minimum && Percentage <= GeneralProgress.Maximum)
            {
                // Show the percentage on the progress bar
                GeneralProgress.Value = Percentage;
            }
        }

        private async void CreateServerData_Click(object sender, EventArgs e)
        {
            // Request for the name of the server data folder
            string DataName = Microsoft.VisualBasic.Interaction.InputBox("Insert the name for your server data folder:", "Server Data creator");

            // Check that is not null or empty, if it does return
            if (string.IsNullOrWhiteSpace(DataName))
            {
                ServerOutput.AppendLine("Looks like the name that you entered is not valid, or you closed the window.");
                return;
            }

            // Store the path
            string NewPath = Path.Combine(Data, DataName);

            // Make sure that the folder does not exists
            if (Directory.Exists(NewPath))
            {
                ServerOutput.AppendLine("The name that you just entered is already being used.");
                return;
            }

            // Lock both of the selectors to avoid unexpected behaviours
            LimitAvailableControls(true);

            // Check if the user wants to download the cfx-server-data repo
            if (Properties.Settings.Default.DownloadScripts)
            {
                // Store the location of the file
                string DataFile = Path.Combine(Data, "cfx-server-data.zip");
                // Notify the user about the download
                ServerOutput.AppendLine("Downloading the cfx-server-data repository...");
                // And start getting the file
                await DownloadClient.DownloadFileTaskAsync("https://github.com/citizenfx/cfx-server-data/archive/master.zip", DataFile);
                // Wait until the file has been downloaded
                while (DownloadClient.IsBusy)
                {
                    await Task.Delay(0);
                }
                // Notify the user about the extraction
                ServerOutput.AppendLine("The file was downloaded, extracting the content...");
                // And extract the files
                await Task.Run(() => ZipFile.ExtractToDirectory(DataFile, Data));
                ServerOutput.AppendLine("The file has been extracted, no problems found.");
                // Then, rename the folder to the one requested by the user
                Directory.Move(Path.Combine(Data, "cfx-server-data-master"), NewPath);
                // Delete the temporary file
                File.Delete(DataFile);
                // Finally, restore the progress bar status
                GeneralProgress.Value = 0;
            }
            else
            {
                // Create the directory for the server data
                Directory.CreateDirectory(NewPath);
                ServerOutput.AppendLine("New Server Data folder has been created.");
            }

            // Get the string and add a random rcon password to it
            string Config = string.Format(Encoding.UTF8.GetString(Properties.Resources.ServerTemplate), Tools.GenerateSecureString(16));
            // Then, write the file and notify the user
            File.WriteAllText(Path.Combine(NewPath, "server.cfg"), Config);
            ServerOutput.AppendLine("A Template for the new Server Data folder has been created.");

            // Finally, refresh the list of server data folders
            RefreshServerData();
            // And if the server is stopped, enable the selectors
            if (ServerStatus == Status.Stopped)
            {
                LimitAvailableControls(false);
            }
        }

        private void Landing_FormClosing(object sender, FormClosingEventArgs e)
        {
            // If the server process is running, stop it
            StopServerNow();
        }

        private void StopServer_Click(object sender, EventArgs e)
        {
            // If the server process is running, stop it
            if (StopServerNow())
            {
                ServerOutput.AppendLine("FXServer has been stopped by the user.");
            }
        }

        private void ServerInput_KeyDown(object sender, KeyEventArgs e)
        {
            // Check if the key pressed was Enter or Return and the server is running
            if ((e.KeyCode == Keys.Return || e.KeyCode == Keys.Enter) && ServerProcess.IsRunning())
            {
                ServerProcess.StandardInput.WriteLine(ServerInput.Text);
                ServerInput.Text = string.Empty;
            }
        }

        private void AutoRestart_Tick(object sender, EventArgs e)
        {
            // If the current status is running but the process is not there
            if (ServerStatus == Status.Running && !ServerProcess.IsRunning() && Properties.Settings.Default.AutoRestart)
            {
                // Show the last exit code to the user
                // NOTE: This is always going to show 1
                ServerOutput.AppendLine("The server has crashed, exit code: " + ServerProcess.ExitCode);
                // Force a stop just in case
                StopServerNow();
                // Store the build and data folders
                string BuildFolder = Path.Combine(Builds, BuildList.SelectedItem.ToString());
                string DataFolder = Path.Combine(Data, DataList.SelectedItem.ToString());
                // Start the server... again
                StartServerNow();
            }
        }

        private void FiveMLicense_Click(object sender, EventArgs e)
        {
            // Open the License page for FiveM servers on the default browser
            Process.Start("https://keymaster.fivem.net");
        }

        private void EditServerConfig_Click(object sender, EventArgs e)
        {
            // If there is no selected server data, return
            if (DataList.SelectedIndex == -1)
            {
                return;
            }

            // Store the path of our configuration file
            string FilePath = Path.Combine(Data, DataList.SelectedItem.ToString(), "server.cfg");

            // Create a new editor window and show it as a dialog
            Editor FileEditor = new Editor(FilePath);
            FileEditor.ShowDialog();
        }

        private void ResourceDownloader_Click(object sender, EventArgs e)
        {
            // If there is no selected server data, return
            if (DataList.SelectedIndex == -1)
            {
                return;
            }

            // Otherwise, open the downloader window
            Downloader Window = new Downloader(Path.Combine(Data, DataList.SelectedItem.ToString()));
            Window.ShowDialog();
        }

        private void PerformRestart()
        {
            // Disable the autorestart thingy
            AutoRestart.Enabled = false;
            // Stop the server
            StopServerNow();
            // Once is stopped, start it again
            StartServerNow();
            // And enable the autorestart on crash
            AutoRestart.Enabled = true;
        }

        private void ScheduledRestart_Tick(object sender, EventArgs e)
        {
            // If the server is running and the task is over time
            if (ServerStatus == Status.Running && Properties.Settings.Default.ScheduledMode == 0)
            {
                PerformRestart();
            }
            // Otherwise, if the restart is on specific times
            else if (ServerStatus == Status.Running && Properties.Settings.Default.ScheduledMode == 1)
            {
                // Store the current time and restart time
                DateTime Now = DateTime.Now;
                TimeSpan Set = Properties.Settings.Default.ScheduledTime;
                // See if the time is correct
                bool TimeMatches = Now.Hour == Set.Hours && Now.Minute == Set.Minutes && Now.Second == Set.Seconds;

                // If the time matches and there has not been a restart
                if (TimeMatches && !LastRestart)
                {
                    LastRestart = true;
                    PerformRestart();
                }
                // If the time does not matches but there has been a restart
                else if (!TimeMatches && LastRestart)
                {
                    LastRestart = false;
                }
            }
        }

        private void Landing_Shown(object sender, EventArgs e)
        {
            // And refresh the list of server builds and server data
            RefreshServerBuilds();
            RefreshServerData();
            // Set the security protocol as TLS 1.2 (for some reason, SSL3 does not works)
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            // Check if the settings require an update
            if (Properties.Settings.Default.UpgradeRequired)
            {
                // If they do, upgrade and save them
                Properties.Settings.Default.Upgrade();
                Properties.Settings.Default.UpgradeRequired = false;
                Properties.Settings.Default.Save();
            }

            // If there is the user wants scheduled restarts
            if (Properties.Settings.Default.ScheduledRestart)
            {
                // Enable them
                ScheduledRestart.Enabled = true;

                // And, if the user is restarting every few minutes/hours/days
                if (Properties.Settings.Default.ScheduledMode == 0)
                {
                    ScheduledRestart.Interval = (int)Properties.Settings.Default.ScheduledTime.TotalMilliseconds;
                }
                // Otherwise, set another interval
                else if (Properties.Settings.Default.ScheduledMode == 1)
                {
                    ScheduledRestart.Interval = 100;
                }
            }
        }
    }
}
