using LambentLight.Builds;
using LambentLight.DataFolders;
using Serilog;
using System;
using System.Linq;
using System.Windows.Forms;

namespace LambentLight
{
    public partial class FormLanding : Form
    {
        #region Initialization

        public FormLanding()
        {
            InitializeComponent();
        }

        private void FormLanding_Shown(object sender, EventArgs e)
        {
            // Show the dialog initializing the managers
            Log.Debug("Landing Form was shown to the user");
            new FormInit().ShowDialog();

            // Once we go back, load the list of data folders
            UpdateDataFolders();
        }

        #endregion

        #region Tools

        public void UpdateDataFolders()
        {
            DataFoldersComboBox.Items.Clear();
            foreach (DataFolder folder in Managers.FolderManager.Folders)
            {
                DataFoldersComboBox.Items.Add(folder);
            }
            if (DataFoldersComboBox.Items.Count != 0)
            {
                DataFoldersComboBox.SelectedIndex = 0;
            }
        }

        #endregion

        #region Buttons

        private void DataFolderSettingsButton_Click(object sender, EventArgs e)
        {
            if (DataFoldersComboBox.SelectedItem != null)
            {
                new FormFolderConfig((DataFolder)DataFoldersComboBox.SelectedItem).ShowDialog();
            }
        }

        private async void DataFoldersRefreshButton_Click(object sender, EventArgs e)
        {
            await Managers.FolderManager.Update();
            UpdateDataFolders();
        }

        private async void StartToolStripButton_Click(object sender, EventArgs e)
        {
            // If the server is running, return
            if (Managers.RuntimeManager.IsRunning)
            {
                Log.Warning("User attempted to start the server from the UI, but is already running");
                return;
            }

            // If there is no server data folder selected, return
            if (DataFoldersComboBox.SelectedItem == null)
            {
                Log.Warning("No Data Folder was selected on the UI to start the server");
                return;
            }

            // Otherwise, get the data folder and create a place for the build
            DataFolder folder = (DataFolder)DataFoldersComboBox.SelectedItem;
            Build build = null;

            // Check what build he wants to use
            // If he wants to use the most recent build
            if (folder.Config.BuildUseRecent)
            {
                // If there are no builds to use, return
                if (Managers.BuildManager.Builds.Count == 0)
                {
                    Log.Error($"Data Folder {folder.Name} wants an up to date Build, but there are none available");
                    return;
                }

                // Otherwise, select the first build
                build = Managers.BuildManager.Builds[0];
            }
            // If we need to use a specific Build
            else
            {
                // Try to get the build specified in the config
                Build found = Managers.BuildManager.Builds.Where(x => x.Name == folder.Config.BuildSpecific).FirstOrDefault();

                // If the Build was not found, return
                if (found == null)
                {
                    Log.Error($"Build {folder.Config.BuildSpecific} was not found for Data Folder {folder.Name}");
                    return;
                }

                // If it was found, save it
                build = found;
            }

            // Finally, go ahead and start the build
            await Managers.RuntimeManager.Start(build, folder);
        }

        #endregion
    }
}
