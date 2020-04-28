using LambentLight.Builds;
using LambentLight.DataFolders;
using System;
using System.Linq;
using System.Windows.Forms;

namespace LambentLight
{
    /// <summary>
    /// Form for changing the configuration of a specific Data Folder.
    /// </summary>
    public partial class FormFolderConfig : Form
    {
        /// <summary>
        /// The Data Folder that owns this configuration.
        /// </summary>
        public DataFolder Folder { get; private set; }

        public FormFolderConfig(DataFolder folder)
        {
            // Initialize the UI
            InitializeComponent();

            // Save the folder
            Folder = folder;

            // Load the games
            foreach (string game in Enum.GetNames(typeof(Game)))
            {
                GameComboBox.Items.Add(game);
            }
            // And builds
            foreach (Build build in Managers.BuildManager.Builds)
            {
                BuildsComboBox.Items.Add(build);
            }

            // And load the settings
            // Game
            GameComboBox.SelectedIndex = (int)folder.Config.Game;
            // License
            LicenseCheckBox.Checked = folder.Config.LicenseUseCustom;
            LicenseTextBox.Enabled = folder.Config.LicenseUseCustom;
            LicenseTextBox.Text = folder.Config.LicenseCustom;
            // CFX Build
            if (folder.Config.BuildUseRecent)
            {
                BuildsLatestCheckBox.Checked = true;
                BuildsComboBox.Enabled = false;
            }
            else
            {
                BuildsLatestCheckBox.Checked = false;
                BuildsComboBox.Enabled = true;
                BuildsComboBox.SelectedItem = Managers.BuildManager.Builds.Where(x => x.Name == folder.Config.BuildSpecific).FirstOrDefault();
            }
            // OneSync
            OneSyncCheckBox.Checked = folder.Config.OneSync;
            OneSyncInfCheckBox.Enabled = folder.Config.OneSync;
            OneSyncInfCheckBox.Checked = folder.Config.OneSyncInfinity;
            // Server Configuration
            ConfigTextBox.Text = folder.Config.Config;
        }

        private void Save()
        {
            // Game
            Folder.Config.Game = (Game)GameComboBox.SelectedIndex;
            // License
            Folder.Config.LicenseUseCustom = LicenseCheckBox.Checked;
            Folder.Config.LicenseCustom = LicenseTextBox.Text;
            // CFX Build
            Folder.Config.BuildUseRecent = BuildsLatestCheckBox.Checked;
            if (BuildsLatestCheckBox.Checked)
            {
                Folder.Config.BuildSpecific = "";
            }
            else
            {
                Folder.Config.BuildSpecific = ((Build)BuildsComboBox.SelectedItem).Name;
            }
            // OneSync
            Folder.Config.OneSync = OneSyncCheckBox.Checked;
            Folder.Config.OneSyncInfinity = OneSyncInfCheckBox.Checked;
            // Server Configuration
            Folder.Config.Config = ConfigTextBox.Text;

            Folder.SaveConfig();
        }

        private void LicenseCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            LicenseTextBox.Enabled = LicenseCheckBox.Checked;
        }

        private void OneSyncCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (!OneSyncCheckBox.Checked)
            {
                OneSyncInfCheckBox.Checked = false;
            }
            OneSyncInfCheckBox.Enabled = OneSyncCheckBox.Checked;
        }

        private void BuildsLatestCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            BuildsComboBox.Enabled = !BuildsLatestCheckBox.Checked;
        }

        private void AcceptButton_Click(object sender, EventArgs e)
        {
            Save();
            Close();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
