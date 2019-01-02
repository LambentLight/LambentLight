using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Reflection;
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
            // And refresh the list of server builds and server data
            RefreshServerBuilds();
            RefreshServerData();
        }

        private void RefreshServerBuilds()
        {
            // Clear the list of items
            BuildList.Items.Clear();
            // Create a new web parser
            HtmlWeb Web = new HtmlWeb();
            // Get the document from the FiveM build list
            HtmlAgilityPack.HtmlDocument Doc = Web.Load("https://runtime.fivem.net/artifacts/fivem/build_server_windows/master/");
            // Create a list of versions from the links without the "/" at the end
            List<string> Versions = Doc.DocumentNode.SelectNodes("//a").Select(X => X.InnerText.TrimEnd('/')).ToList();

            // Iterate over the versions that we got without the "Previous Directory" button or "Revoked" folder
            foreach (string Version in Versions.Where(X => X != ".." && X != "revoked"))
            {
                // And add that version into the ComboBox
                BuildList.Items.Add(Version);
            }

            // Finally, restore the last build used
            RestoreLastBuildUsed();
        }

        private void RefreshServerData()
        {
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

            // Finally, restore the last server data used
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

        private void OpenSettings_Click(object sender, EventArgs e)
        {
            // Create an instance of the Settings window
            Settings SettingsWindow = new Settings();
            // And show it as a dialog (so the user is unable to launch a server)
            SettingsWindow.ShowDialog();
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
            // If there is no build selected, return
            if (BuildList.SelectedIndex == -1 || DataList.SelectedIndex == -1)
            {
                ServerOutput.AppendLine("You need to select a Build and a Server Data");
                return;
            }

            // Store the path that we are going to use
            string BuildFolder = Path.Combine(Builds, BuildList.SelectedItem.ToString());

            // Check if the FiveM build exists locally
            if (!Directory.Exists(BuildFolder))
            {
                // Looks like there is no build, notify the user
                ServerOutput.AppendLine("The build was not found locally, attempting a download...");
                // Store the download origin and destination
                Uri DownloadOrigin = new Uri(string.Format(DownloadUrl, BuildList.SelectedItem.ToString()));
                string DownloadLocation = Path.Combine(Builds, BuildList.SelectedItem.ToString() + ".zip");
                // And download the file
                await DownloadClient.DownloadFileTaskAsync(DownloadOrigin, DownloadLocation);
                // Wait until the file has been downloaded
                while (DownloadClient.IsBusy)
                {
                    await Task.Delay(0);
                }
                // Check if a folder already exists
                if (Directory.Exists(BuildFolder))
                {
                    // If it does, delete it recursively
                    Directory.Delete(BuildFolder, true);
                }
                // Create the folder for the current build
                Directory.CreateDirectory(BuildFolder);
                // Notify the user about the extraction
                ServerOutput.AppendLine("The file was downloaded, extracting the content...");
                // And extract the files
                await Task.Run(() => ZipFile.ExtractToDirectory(DownloadLocation, BuildFolder));
                // Finally, restore the progress bar status
                GeneralProgress.Value = 0;
            }
        }

        private void DownloadClient_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            // Get the download percentage and show it on the progress bar
            GeneralProgress.Value = (int)((float)e.BytesReceived / e.TotalBytesToReceive * 100f);
        }
    }
}
