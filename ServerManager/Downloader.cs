using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ServerManager
{
    public partial class Downloader : Form
    {
        /// <summary>
        /// The folder of the server Data.
        /// </summary>
        private string DataFolder;
        /// <summary>
        /// Web Client used for downloads.
        /// </summary>
        private WebClient Client = new WebClient();
        /// <summary>
        /// List of resources that the user can download.
        /// </summary>
        private List<Resource> Resources = new List<Resource>();

        public Downloader(string DataFolder)
        {
            // Initialize the UI
            InitializeComponent();
            // Store the folder
            this.DataFolder = DataFolder;
            // And refresh the list of resources
            RefreshList();
        }

        public void RefreshList()
        {
            // Make a request and store the response
            string Response = Client.DownloadString(Properties.Settings.Default.Resources);
            // Parse the response
            Resources = JsonConvert.DeserializeObject<List<Resource>>(Response);
            // Clean the items
            ResourceSelector.Items.Clear();
            // And add the items
            foreach (Resource Res in Resources)
            {
                ResourceSelector.Items.Add($"{Res.Name} {Res.Version}");
            }
        }

        private async void ResourceSelector_DoubleClick(object sender, EventArgs e)
        {
            // If there is no rows selected, return
            if (ResourceSelector.SelectedIndex == -1)
            {
                return;
            }

            // Try to get the selected resource
            Resource Selected = Resources.SingleOrDefault(X => $"{X.Name} {X.Version}" == ResourceSelector.SelectedItem.ToString());

            // IF no resource was found
            if (Selected == null)
            {
                // Notify the user and return
                Status.Text = $"Unable to find '{ResourceSelector.SelectedItem.ToString()}'";
                return;
            }

            // If there is a custom license
            if (Selected.License != null)
            {
                // Get the license
                string Response = Client.DownloadString(Selected.License);
                // And show a dialog to the user
                DialogResult Question = MessageBox.Show($"Please read the following license:\n\n{Response}\n\nDo you accept the resource License?", "License Agrement", MessageBoxButtons.YesNo);

                // Check if the user accepted the license
                if (Question != DialogResult.Yes)
                {
                    Status.Text = $"Install of {Selected.Name} cancelled by the user.";
                    return;
                }
            }

            // Make sure that there is not installed already
            string Destination = Path.Combine(DataFolder, "resources", Selected.Folder);
            if (Directory.Exists(Destination))
            {
                // If it does, ask the user
                DialogResult Replace = MessageBox.Show("The resource already exists, do you want to replace it?", "Resource already exists", MessageBoxButtons.YesNo);
                // If the user pressed other than yes
                if (Replace != DialogResult.Yes)
                {
                    Status.Text = "Resource already exists.";
                    return;
                }
                // Otherwise, delete the folder
                else
                {
                    Directory.Delete(Destination, true);
                }
            }

            // Disable the list of resources so we don't fuck things up
            ResourceSelector.Enabled = false;

            // If there is no temporary folder, create it
            string Temp = Path.Combine(DataFolder, "temp");
            if (!Directory.Exists(Temp))
            {
                Directory.CreateDirectory(Temp);
            }

            // Notify the user about the download
            Status.Text = $"Downloading {Selected.Name} {Selected.Version}";

            // Create the URL for the destination
            string Downloaded = Path.Combine(Temp, $"{Selected.Folder}" + (Selected.Compresion == CompressionType.Zip ? ".zip": ".7z"));
            // Make sure that the file does not exists
            if (File.Exists(Downloaded))
            {
                File.Delete(Downloaded);
            }
            // Download the file
            await Client.DownloadFileTaskAsync(Selected.Download, Downloaded);

            // Notify the user that the download has finished
            Status.Text = $"Finished download of {Selected.Name}, extracting...";
            // Store the output directory
            string OutputDir = Path.Combine(Temp, Selected.Folder);
            // Make sure that is gone
            if (Directory.Exists(OutputDir))
            {
                Directory.Delete(OutputDir, true);
            }
            // Use the appropiate extraction format
            switch (Selected.Compresion)
            {
                case CompressionType.Zip:
                    await Task.Run(() => ZipFile.ExtractToDirectory(Downloaded, OutputDir));
                    break;
                default:
                    throw new NotSupportedException("That compression format is not supported at this moment.");
            }

            // Delete the file
            File.Delete(Downloaded);

            // Extraction finished, move the folder
            Status.Text = "Extraction finished, moving the folder...";
            Directory.Move(OutputDir, Destination);
            Status.Text = $"Done! {Selected.Name} {Selected.Version} has been installed";

            // Finally, restore the menu
            ResourceSelector.Enabled = true;
        }
    }
}
