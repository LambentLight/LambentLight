using LambentLight.DataFolders;
using Serilog;
using System;
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

        #endregion
    }
}
