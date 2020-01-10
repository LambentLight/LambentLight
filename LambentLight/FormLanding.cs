using LambentLight.Config;
using LambentLight.Extensions;
using LambentLight.Managers;
using LambentLight.Managers.Builds;
using LambentLight.Managers.Database;
using LambentLight.Managers.DataFolders;
using LambentLight.Managers.Resources;
using LambentLight.Managers.Runtime;
using LambentLight.Properties;
using NLog;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace LambentLight
{
    public partial class FormLanding : Form
    {
        #region Private Fields

        /// <summary>
        /// The logger for our current class.
        /// </summary>
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        #endregion

        #region Public Properties

        /// <summary>
        /// Sets the locked status of some of the UI elements.
        /// </summary>
        public bool Locked
        {
            set
            {
                StartToolStripMenuItem.Enabled = !value;
                StopToolStripMenuItem.Enabled = value;
                RestartToolStripMenuItem.Enabled = value;
                CreateToolStripMenuItem.Enabled = !value;

                BuildsListBox.Enabled = !value;
                BuildsRefreshButton.Enabled = !value;
                DataFolderComboBox.Enabled = !value;
                DataFolderRefreshButton.Enabled = !value;

                ConsoleInputTextBox.Enabled = value;
                ConsoleSendButton.Enabled = value;

                ResourceStartButton.Enabled = !value;
                ResourceRestartButton.Enabled = !value;
                ResourceStopButton.Enabled = !value;
            }
        }

        #endregion

        #region Constructor and Loading

        public FormLanding()
        {
            // Initialize the UI elements
            InitializeComponent();

            // Add all of the supported games
            foreach (string value in Enum.GetNames(typeof(Game)))
            {
                GameComboBox.Items.Add(value.SpaceOnUpperCase());
            }

            // Load the RTF text
            AboutRichTextBox.Rtf = Resources.About;

            // Unlock all of the UI Elements
            Locked = false;
        }

        private void Landing_Load(object sender, EventArgs e)
        {
            // Select the same game as the last session
            GameComboBox.SelectedIndex = (int)Program.Config.Game;

            // Update the list of Builds and Data Folders
            BuildManager.Refresh();
            DataFolderManager.Refresh();
            // And and fill their respective lists
            BuildsListBox.Fill(BuildManager.Builds, true);
            DataFolderComboBox.Fill(DataFolderManager.Folders, true);
        }

        private async void Landing_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Ask the user if he wants to close the server
            DialogResult result = MessageBox.Show("Closing LambentLight will stop the server and close the MySQL Connection.\nAre you sure that you want to exit LambentLight?", "Server is Running", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            // If the result is not yes, cancel the event and return
            if (result != DialogResult.Yes)
            {
                e.Cancel = true;
                return;
            }

            // If the server is running, stop it
            await RuntimeManager.Stop();
            // Disconnect the database if there is an open connection
            DatabaseManager.Disconnect();
        }

        private void MainTabControl_Selected(object sender, TabControlEventArgs e)
        {
            // If the user selected the Server Configuration tab and there is a data folder selected
            if (e.TabPage == ConfigurationTabPage && DataFolderComboBox.SelectedItem != null)
            {
                // Set the text to the configuration of the server
                ConfigurationTextBox.Text = ((DataFolder)DataFolderComboBox.SelectedItem).Configuration;
            }
            // If the user selected the Resources tab and there is a data folder selected and it exists
            else if (e.TabPage == ResourcesTabPage && DataFolderComboBox.SelectedItem != null && InstalledListBox.Items.Count == 0)
            {
                // Update the list of installed resources
                RefreshInstalledResources();
            }
        }

        #endregion

        #region Strip Items

        private async void StartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Ensure that we have an item available
            if (BuildsListBox.SelectedItem == null)
            {
                // If not, notify the user and return
                Logger.Info("You have not selected a FiveM/CitizenFX server build");
                return;
            }
            // Do the same with server data folders
            if (DataFolderComboBox.SelectedItem == null)
            {
                // Notify and return
                Logger.Info("You have not selected a Server Data folder");
                return;
            }

            // Lock the UI Elements just in case
            Locked = true;
            StopToolStripMenuItem.Enabled = false;
            ConsoleInputTextBox.Enabled = false;
            ConsoleSendButton.Enabled = false;

            // Start the build with the selected options
            Locked = await RuntimeManager.Start((Build)BuildsListBox.SelectedItem, (DataFolder)DataFolderComboBox.SelectedItem);
        }

        private async void StopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // If there is a shutdown in progress
            if (RuntimeManager.IsShutdownInProgress)
            {
                // Ask the user if he wants to force the closure of the server
                DialogResult result = MessageBox.Show("Do you want to force a server shutdown?", "Force Shutdown?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                // If he does, mark a forced shutdown and return
                if (result == DialogResult.Yes)
                {
                    RuntimeManager.ForceServerShutdown = true;
                }
            }
            // Otherwise
            else
            {
                // Call a new server shutdown
                Locked = !await RuntimeManager.Stop();
            }
        }

        private async void RestartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Tell the process manager to restart the existing server
            await RuntimeManager.Restart();
        }

        private async void CreateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Create the new form
            FormCreator CreatorForm = new FormCreator();
            // Show the form as a dialog
            CreatorForm.ShowDialog();
            // Once we have returned, dispose the dialog
            CreatorForm.Dispose();

            // If there is a valid server data folder
            if (CreatorForm.NewDataFolder != null)
            {
                // Lock the fields
                Locked = true;
                // Tell the Data Folder to recreate itself
                await CreatorForm.NewDataFolder.Recreate(CreatorForm.RCONTextBox.Text, CreatorForm.SHVCheckBox.Checked);
                // Refresh the list of Data Folders and fill them
                DataFolderManager.Refresh();
                DataFolderComboBox.Fill(DataFolderManager.Folders);
                // And select the new Data Folder
                DataFolderComboBox.SelectedItem = CreatorForm.NewDataFolder;
                // Finally unlock the fields
                Locked = false;
            }
        }

        private void SettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Create a new settings window and open it up as a dialog
            FormConfig config = new FormConfig();
            config.ShowDialog();
            // Once is closed, dispose it
            config.Dispose();
        }

        #endregion

        #region Selectors
        
        private void GameComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Save the index of the selected game in the configuration
            Program.Config.Game = (Game)GameComboBox.SelectedIndex;
            Program.Config.Save();

            // And refresh the resources on the installer
            RefreshResourceInstaller();
        }

        private void DataFolderComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Refresh the list of installed resources
            RefreshInstalledResources();

            // If the selected tab is the one with the configuration and a Data Folder is selected
            if (MainTabControl.SelectedTab == ConfigurationTabPage && DataFolderComboBox.SelectedItem != null)
            {
                // Set the configuration text to the one of the selected Data Folder
                ConfigurationTextBox.Text = ((DataFolder)DataFolderComboBox.SelectedItem).Configuration;
            }
        }

        private void DataFolderBrowseButton_Click(object sender, EventArgs e)
        {
            // If there is a Data Folder selected, open it up
            if (DataFolderComboBox.SelectedItem != null)
            {
                Process.Start(((DataFolder)DataFolderComboBox.SelectedItem).Location);
            }
        }

        private void DataFolderRefreshButton_Click(object sender, EventArgs e)
        {
            // Refresh the list of Data Folders
            DataFolderManager.Refresh();
            DataFolderComboBox.Fill(DataFolderManager.Folders);
        }

        #endregion

        #region Server Console

        private void ConsoleClearButton_Click(object sender, EventArgs e)
        {
            // Just wipe everything on the LogTextBox
            ConsoleTextBox.Text = string.Empty;
        }

        private void ConsoleSendButton_Click(object sender, EventArgs e)
        {
            // Send the command to the server
            RuntimeManager.SendCommand(ConsoleInputTextBox.Text);
            // And clear the input TextBox
            ConsoleInputTextBox.Text = string.Empty;
        }

        #endregion

        #region Resources - Already Installed

        private void InstalledListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            // If there is a resource to uninstall, enable the button
            InstalledUninstallButton.Enabled = InstalledListBox.SelectedItem != null;
            // Then, enable the buttons if there is a resource selected and the server is running
            ResourceStartButton.Enabled = InstalledListBox.SelectedItem != null && RuntimeManager.IsServerRunning;
            ResourceRestartButton.Enabled = InstalledListBox.SelectedItem != null && RuntimeManager.IsServerRunning;
            ResourceStopButton.Enabled = InstalledListBox.SelectedItem != null && RuntimeManager.IsServerRunning;
        }

        private void ResourceStartButton_Click(object sender, EventArgs e)
        {
            // Start the resource via commands
            RuntimeManager.SendCommand($"start {InstalledListBox.SelectedItem.ToString()}");
        }

        private void ResourceRestartButton_Click(object sender, EventArgs e)
        {
            // Restart the resource via commands
            RuntimeManager.SendCommand($"restart {InstalledListBox.SelectedItem.ToString()}");
        }

        private void ResourceStopButton_Click(object sender, EventArgs e)
        {
            // Stop the resource via commands
            RuntimeManager.SendCommand($"stop {InstalledListBox.SelectedItem.ToString()}");
        }

        private void InstalledRefreshButton_Click(object sender, EventArgs e)
        {
            // Just refresh the list of resources that are installed
            RefreshInstalledResources();
        }

        private void InstalledUninstallButton_Click(object sender, EventArgs e)
        {
            // Get the resource that we are trying to uninstall
            InstalledResource installed = (InstalledResource)InstalledListBox.SelectedItem;
            // Try to find a resource with the same folder name as the one that we are going to delete
            Resource found = ResourceManager.Resources.Where(x => x.More.Install.Destination.ToLower() == installed.Name.ToLower()).FirstOrDefault();
            // If a resource was found, use that name
            // If not, use the folder name
            string name = found == null ? installed.Name : found.Name;

            // Ask the user if he really wants to remove the resource
            DialogResult Result = MessageBox.Show($"Are you sure that you want to uninstall {name}?", "Uninstall Confirmation", MessageBoxButtons.YesNo);

            // If the user confirmed the process
            if (Result == DialogResult.Yes)
            {
                // Remove the selected resource
                installed.Remove();
                // And update the list of installed resources
                RefreshInstalledResources();
            }
        }

        #endregion

        #region Resources - To be Installed

        private void InstallerResourcesListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Disable the install button
            InstallerInstallButton.Enabled = false;
            // And clear the list of versions
            InstallerVersionsListBox.Items.Clear();

            // Cast the selected resource and the extended information
            Resource resource = (Resource)InstallerResourcesListBox.SelectedItem;
            ExtendedResource more = resource.More;

            // If there is a resource and the extended information is also present
            if (resource != null && more != null)
            {
                // Add the builds to our version ListBox
                InstallerVersionsListBox.Fill(more.Versions);
            }
        }

        private void InstallerVersionsListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            // If there is a version to install, enable the button
            InstallerInstallButton.Enabled = InstallerVersionsListBox.SelectedItem != null;
        }

        private void InstallerRefreshButton_Click(object sender, EventArgs e)
        {
            // Refresh the list of resources that can be installed
            RefreshResourceInstaller();
        }

        private async void InstallerInstallButton_Click(object sender, EventArgs e)
        {
            // If there is no data folder selected, notify the user and return
            if (DataFolderComboBox.SelectedItem == null)
            {
                Logger.Error("You need to select a Server Data folder!");
                return;
            }

            // Cast the data folder and resource to their real values
            DataFolder folder = (DataFolder)DataFolderComboBox.SelectedItem;
            Resource resource = (Resource)InstallerResourcesListBox.SelectedItem;

            // If the resource is deprecated and there is a replacement for it
            if (!string.IsNullOrWhiteSpace(resource.SupersededBy))
            {
                // Ask the user if he wants to continue with the installation
                DialogResult result = MessageBox.Show($"This resource is no longer updated by it's developer.\nWe recommend that you install {resource.SupersededBy} instad of {resource.Name}.\nDo you want to continue?", "Resource Deprecated", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                // If he does not, return
                if (result == DialogResult.No)
                {
                    return;
                }
            }

            // Get all of the requirements by the selected resource
            Dictionary<Resource, Managers.Resources.Version> requirements = resource.GetRequirements((Managers.Resources.Version)InstallerVersionsListBox.SelectedItem);
            // Create the readable list of resources
            string readable = string.Join(" ", requirements.Select(x => $"{x.Key.Name}-{x.Value.ReadableVersion}"));

            // Notify the user that we are going to install the requirements
            Logger.Info("Installing requirements {0} for {1}", readable, InstallerResourcesListBox.SelectedItem);

            // Iterate over the list of required resources
            foreach (KeyValuePair<Resource, Managers.Resources.Version> requirement in requirements)
            {
                // And install them
                await folder.Install(requirement.Key, requirement.Value);
            }

            // If the user wants to auto-start the resource, add it into the configuration
            if (Program.Config.AddAfterInstalling)
            {
                folder.AddToAutoStart(resource);
            }

            // Tell the server to refresh the list of installed resources
            RuntimeManager.SendCommand("refresh");
            // Notify that we have installed all of the resources
            Logger.Info("Successfully installed {0}", readable);
            // And finally, update the list of installed resources
            RefreshInstalledResources();
        }

        #endregion

        #region Server Configuration

        private void ConfigurationLoadButton_Click(object sender, EventArgs e)
        {
            // If there is a data folder selected
            if (DataFolderComboBox.SelectedItem != null)
            {
                // Load the text and place it on the TextBox
                ConfigurationTextBox.Text = ((DataFolder)DataFolderComboBox.SelectedItem).Configuration;
            }
        }

        private void ConfigurationGenerateButton_Click(object sender, EventArgs e)
        {
            // If there is a data folder selected
            if (DataFolderComboBox.SelectedItem != null)
            {
                // Ask the user if he is sure about this
                DialogResult result = MessageBox.Show("Are you sure that you want to replace the existing configuration?", "Replace Configuration", MessageBoxButtons.YesNo);

                // If the response was yes
                if (result == DialogResult.Yes)
                {
                    // Set the text of the configuration
                    ConfigurationTextBox.Text = ((DataFolder)DataFolderComboBox.SelectedItem).GenerateConfig();
                }
            }
        }

        private void ConfigurationSaveButton_Click(object sender, EventArgs e)
        {
            // If there is a data folder selected
            if (DataFolderComboBox.SelectedItem != null)
            {
                // Save the configuration from TextBox
                ((DataFolder)DataFolderComboBox.SelectedItem).Configuration = ConfigurationTextBox.Text;
            }
        }

        #endregion

        #region Builds

        private void BuildsRefreshButton_Click(object sender, EventArgs e)
        {
            // Refresh the list of builds
            BuildManager.Refresh();
            // And fill the ListBox while selecting the first item
            BuildsListBox.Fill(BuildManager.Builds, true);
        }

        private async void BuildsImportButton_Click(object sender, EventArgs e)
        {
            // Open the file dialog so the user can browse for the ZIP File
            // If he didn't selected a file, return
            if (BuildFileDialog.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            // But if he did, install the build from the file
            await BuildManager.Install(BuildFileDialog.FileName);
        }

        #endregion

        #region Tools

        private void RefreshInstalledResources()
        {
            // Disable the Start, Restart, Stop and Remove buttons
            ResourceStartButton.Enabled = false;
            ResourceRestartButton.Enabled = false;
            ResourceStopButton.Enabled = false;
            InstalledUninstallButton.Enabled = false;

            // If there is no Data Folder selected or it does not exists
            if (DataFolderComboBox.SelectedItem == null || !((DataFolder)DataFolderComboBox.SelectedItem).Exists)
            {
                // Wipe all of the installed resources and return
                InstalledListBox.Items.Clear();
                return;
            }

            // If there is a valid Data Folder, fill the list with the installed resources
            InstalledListBox.Fill(((DataFolder)DataFolderComboBox.SelectedItem).Resources);
        }
        private void RefreshResourceInstaller()
        {
            // Disable the install button and clear the list of versions
            InstallerInstallButton.Enabled = false;
            InstallerVersionsListBox.Items.Clear();
            // And add the updated set of resource
            ResourceManager.Refresh();
            InstallerResourcesListBox.Fill(ResourceManager.Resources);
        }

        #endregion
    }
}
