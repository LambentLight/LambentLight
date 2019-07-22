using NLog;
using NLog.Config;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LambentLight
{
    public partial class Landing : Form
    {
        /// <summary>
        /// The logger for our current class.
        /// </summary>
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// Sets the locked status of some of the UI elements.
        /// </summary>
        public bool Locked
        {
            set
            {
                StartItem.Enabled = !value;
                StopItem.Enabled = value;
                CreateItem.Enabled = !value;
                ExitItem.Enabled = !value;
                BuildsBox.Enabled = !value;
                BuildRefreshButton.Enabled = !value;
                DataBox.Enabled = !value;
                FolderRefreshButton.Enabled = !value;
            }
        }

        public Landing()
        {
            // Initialize the UI elements
            InitializeComponent();
        }

        private void Landing_Load(object sender, EventArgs e)
        {
            // Create a new configuration for NLog
            LoggingConfiguration NewConfig = new LoggingConfiguration();
            // Add a rule for logging to the TextBox
            NewConfig.AddRule(LogLevel.Info, LogLevel.Fatal, new TextBoxTarget() { Box = LogTextBox, Layout = "[${date}] [${level}] ${message}" });
            // Set the already created configuration
            LogManager.Configuration = NewConfig;
            // And filll the Builds and Data folders
            BuildManager.Fill(BuildsBox);
            DataFolderManager.Fill(DataBox);
            // Set the elements to unlocked
            Locked = false;

            // Tell the Web Clients to use TLS 1.2 instead of SSL3
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            // Load the settings
            BuildsTextBox.Text = Properties.Settings.Default.Builds;
            DownloadScriptsCheckBox.Checked = Properties.Settings.Default.DownloadScripts;
            CreateConfigCheckBox.Checked = Properties.Settings.Default.CreateConfig;
        }

        private async void StartItem_Click(object sender, EventArgs e)
        {
            // Ensure that we have an item available
            if (BuildsBox.SelectedItem == null)
            {
                // If not, notify the user and return
                Logger.Info("You have not selected a FiveM/CitizenFX server build");
                return;
            }
            // Do the same with server data folders
            if (DataBox.SelectedItem == null)
            {
                // Notify and return
                Logger.Info("You have not selected a Server Data folder");
                return;
            }

            // Start the build with the selected options
            Locked = await ServerManager.Start((Build)BuildsBox.SelectedItem, (DataFolder)DataBox.SelectedItem);
        }

        private void StopItem_Click(object sender, EventArgs e)
        {
            // Stop the server if is present and unlock the controls
            ServerManager.Stop();
            Locked = false;
        }

        private async void CreateItem_Click(object sender, EventArgs e)
        {
            // Ask the user for inputing a server data folder name
            string FolderName = Microsoft.VisualBasic.Interaction.InputBox("Please insert a name for the new Server Data Folder:", "New Server Data Folder");
            // Lock the fields
            Locked = true;
            // Create a server data folder
            DataFolder NewFolder = await DataFolderManager.Create(FolderName);
            // If the creation of the new folder succeded
            if (NewFolder != null)
            {
                // Update the fields
                DataFolderManager.Fill(DataBox);
                // And select the new item
                DataBox.SelectedItem = NewFolder;
            }
            // Then unlock the fields
            Locked = false;
        }

        private void ExitItem_Click(object sender, EventArgs e)
        {
            // Close the current form
            Close();
        }

        private void BuildRefreshButton_Click(object sender, EventArgs e)
        {
            // Refresh the list of builds
            BuildManager.Fill(BuildsBox);
        }

        private void FolderRefreshButton_Click(object sender, EventArgs e)
        {
            // Refresh the folders of data
            DataFolderManager.Fill(DataBox);
        }

        private void VisibleTextBox_CheckedChanged(object sender, EventArgs e)
        {
            // Change the enabled status of the License TextBox
            LicenseTextBox.Enabled = VisibleCheckBox.Checked;
            SaveLicenseButton.Enabled = VisibleCheckBox.Checked;
            // If the CheckBox is enabled
            if (VisibleCheckBox.Checked)
            {
                // Fill the text box with the license
                LicenseTextBox.Text = Properties.Settings.Default.License;
            }
            // Otherwise
            else
            {
                // Delete it
                LicenseTextBox.Text = string.Empty;
            }
        }

        private void GenerateLicenseButton_Click(object sender, EventArgs e)
        {
            // Open the FiveM Keymaster page
            Process.Start("https://keymaster.fivem.net");
        }

        private void SaveLicenseButton_Click(object sender, EventArgs e)
        {
            // Save the license on the text box
            Properties.Settings.Default.License = LicenseTextBox.Text;
            Properties.Settings.Default.Save();
        }

        private void SaveAPIsButton_Click(object sender, EventArgs e)
        {
            // Save the URLs on the configuration
            Properties.Settings.Default.Builds = BuildsTextBox.Text;
            Properties.Settings.Default.Save();
        }

        private void DownloadScriptsCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            // Save the curent status on the settings
            Properties.Settings.Default.DownloadScripts = DownloadScriptsCheckBox.Checked;
            Properties.Settings.Default.Save();
        }

        private void CreateConfigCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            // Save the curent status on the settings
            Properties.Settings.Default.CreateConfig = CreateConfigCheckBox.Checked;
            Properties.Settings.Default.Save();
        }

        private void AutoRestartCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            // Save the curent status on the settings
            Properties.Settings.Default.AutoRestart = AutoRestartCheckBox.Checked;
            Properties.Settings.Default.Save();
        }
    }
}
