using LambentLight.Config;
using LambentLight.Database;
using LambentLight.Extensions;
using Microsoft.VisualBasic;
using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace LambentLight
{
    public partial class Configurator : Form
    {
        #region Constructor

        public Configurator()
        {
            // Initialize the UI Elements
            InitializeComponent();

            // Iterate over the time measurements
            foreach (string value in Enum.GetNames(typeof(Time)))
            {
                // Add the item into the combo box
                WaitComboBox.Items.Add(value);
            }

        }

        private void Config_Load(object sender, EventArgs e)
        {
            // Load the settings
            ReloadSettings();
        }

        #endregion

        #region Tools

        private void ReloadSettings()
        {
            // And load all of the settings
            DownloadScriptsCheckBox.Checked = Program.Config.Creator.DownloadScripts;
            CreateConfigCheckBox.Checked = Program.Config.Creator.CreateConfig;
            AddToConfigCheckBox.Checked = Program.Config.AddAfterInstalling;
            RemoveFromConfigCheckBox.Checked = Program.Config.RemoveAfterUninstalling;

            WaitCheckBox.Checked = Program.Config.Wait;
            WaitTextBox.Text = Program.Config.WaitTime.ToString();
            WaitComboBox.SelectedIndex = (int)Program.Config.WaitMeasurement;
            KickCheckBox.Checked = Program.Config.KickEveryone;

            RestartEveryCheckBox.Checked = Program.Config.AutoRestart.Cron;
            RestartAtCheckBox.Checked = Program.Config.AutoRestart.Daily;
            RestartEveryTextBox.Text = Program.Config.AutoRestart.CronTime.ToString();
            RestartAtTextBox.Text = Program.Config.AutoRestart.DailyTime.ToString();

            BuildsTextBox.Text = Program.Config.Builds;
            ResourcesListBox.Items.Clear();
            ResourcesListBox.Fill(Program.Config.Repos);

            ApplyCheckBox.Checked = Program.Config.MySQL.Apply;
            ManuallyCheckBox.Checked = Program.Config.MySQL.Manually;

            AutoRestartCheckBox.Checked = Program.Config.RestartOnCrash;
            ClearCacheCheckBox.Checked = Program.Config.ClearCache;
        }

        #endregion

        #region Authentication - CFX

        private void LicenseVisibleCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            // Change the enabled status of the License TextBox and Button
            LicenseTextBox.Enabled = LicenseVisibleCheckBox.Checked;
            LicenseSaveButton.Enabled = LicenseVisibleCheckBox.Checked;
            // And populate the License correctly
            LicenseTextBox.Text = LicenseVisibleCheckBox.Checked ? Program.Config.CFXToken : string.Empty;
        }

        private void LicenseGenerateButton_Click(object sender, EventArgs e)
        {
            // Open the FiveM Keymaster page
            Process.Start("https://keymaster.fivem.net");
        }

        private void LicenseSaveButton_Click(object sender, EventArgs e)
        {
            // Save the license on the text box
            Program.Config.CFXToken = LicenseTextBox.Text;
            Program.Config.Save();
        }

        #endregion

        #region Authentication - Steam

        private void SteamVisibleCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            // Change the enabled status of the Steam TextBox and Button
            SteamTextBox.Enabled = SteamVisibleCheckBox.Checked;
            SteamSaveButton.Enabled = SteamVisibleCheckBox.Checked;
            // And populate the API Key correctly
            SteamTextBox.Text = SteamVisibleCheckBox.Checked ? Program.Config.SteamToken : string.Empty;
        }

        private void SteamGenerateButton_Click(object sender, EventArgs e)
        {
            // Open the Steam API Key Registration form
            Process.Start("https://steamcommunity.com/dev/apikey");
        }

        private void SaveSteamButton_Click(object sender, EventArgs e)
        {
            // Save the Steam API on the text box
            Program.Config.SteamToken = SteamTextBox.Text;
            Program.Config.Save();
        }

        #endregion

        #region Authentication - MySQL

        private void ConnectionCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            // Change the enabled status of the License TextBox and Button
            ConnectionTextBox.Enabled = ConnectionCheckBox.Checked;
            ConnectionButton.Enabled = ConnectionCheckBox.Checked;
            // And populate the TextBox correctly
            ConnectionTextBox.Text = ConnectionCheckBox.Checked ? Program.Config.MySQL.Connection : string.Empty;
        }

        private void ConnectionButton_Click(object sender, EventArgs e)
        {
            // Just save it
            Program.Config.MySQL.Connection = ConnectionTextBox.Text;
            Program.Config.Save();
            // And tell the database manager to reconnect
            DatabaseManager.Connect();
        }

        #endregion

        #region Runtime

        private void ClearCacheCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            // Save the curent status on the settings
            Program.Config.ClearCache = ClearCacheCheckBox.Checked;
            Program.Config.Save();
        }

        private void AutoRestartCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            // Save the curent status on the settings
            Program.Config.RestartOnCrash = AutoRestartCheckBox.Checked;
            Program.Config.Save();
        }

        private void WaitCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            // Save the curent status on the settings
            Program.Config.Wait = WaitCheckBox.Checked;
            Program.Config.Save();

            // Set the enabled status of the respective items
            WaitTextBox.Enabled = WaitCheckBox.Checked;
            WaitComboBox.Enabled = WaitCheckBox.Checked;
        }

        private void WaitSaveButton_Click(object sender, EventArgs e)
        {
            // Try to parse the text box contents
            try
            {
                Program.Config.WaitTime = int.Parse(WaitTextBox.Text);
            }
            // If we have failed
            catch (FormatException)
            {
                MessageBox.Show("The format for the 'Wait' time is invalid.");
                return;
            }
            // If we succeeded, save it
            Program.Config.Save();
        }

        private void KickCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            // Save the curent status on the settings
            Program.Config.KickEveryone = KickCheckBox.Checked;
            Program.Config.Save();
        }

        #endregion

        #region Data Folders
        
        private void DownloadScriptsCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            // Save the curent status on the settings
            Program.Config.Creator.DownloadScripts = DownloadScriptsCheckBox.Checked;
            Program.Config.Save();
        }

        private void CreateConfigCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            // Save the curent status on the settings
            Program.Config.Creator.CreateConfig = CreateConfigCheckBox.Checked;
            Program.Config.Save();
        }

        private void AddToConfigCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            // Save the curent status on the settings
            Program.Config.AddAfterInstalling = AddToConfigCheckBox.Checked;
            Program.Config.Save();
        }

        private void RemoveFromConfigCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            // Save the curent status on the settings
            Program.Config.RemoveAfterUninstalling = RemoveFromConfigCheckBox.Checked;
            Program.Config.Save();
        }

        private void ApplyCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            Program.Config.MySQL.Apply = ApplyCheckBox.Checked;
            Program.Config.Save();
        }

        private void ManuallyCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            Program.Config.MySQL.Manually = ManuallyCheckBox.Checked;
            Program.Config.Save();
        }

        #endregion

        #region Schedule

        private void RestartEveryCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            // Save the curent status on the settings
            Program.Config.AutoRestart.Cron = RestartEveryCheckBox.Checked;
            Program.Config.Save();
        }

        private void RestartEveryButton_Click(object sender, EventArgs e)
        {
            // Try to parse the text box contents
            try
            {
                Program.Config.AutoRestart.CronTime = TimeSpan.Parse(RestartEveryTextBox.Text);
            }
            // If we have failed
            catch (FormatException)
            {
                MessageBox.Show("The format for the 'Restart every' time is invalid.");
                return;
            }
            // If we succeeded, save it
            Program.Config.Save();
        }

        private void RestartAtCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            // Save the curent status on the settings
            Program.Config.AutoRestart.Daily = RestartAtCheckBox.Checked;
            Program.Config.Save();
        }

        private void RestartAtButton_Click(object sender, EventArgs e)
        {
            // Try to parse the text box contents
            try
            {
                Program.Config.AutoRestart.DailyTime = TimeSpan.Parse(RestartAtTextBox.Text);
            }
            // If we have failed
            catch (FormatException)
            {
                MessageBox.Show("The format for the 'Restart daily at' time is invalid.");
                return;
            }
            // If we succeeded, save it
            Program.Config.Save();
        }

        #endregion

        #region APIs

        private void SaveAPIsButton_Click(object sender, EventArgs e)
        {
            // Save the build URL on the configuration
            Program.Config.Builds = BuildsTextBox.Text;
            Program.Config.Save();
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            // Ask the user for the repository URL
            string repo = Interaction.InputBox("Insert the path of the Remote or Local repository that you want to add.", "Add new Repository");

            // If repo is null or empty, return
            if (string.IsNullOrWhiteSpace(repo))
            {
                MessageBox.Show("The Repository is empty or only has whitespaces.", "Invalid Repository", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // If we got here, add the repository URL into the settings
            Program.Config.Repos.Add(repo);
            // Save the existing settings
            Program.Config.Save();
            // And update the list of repositories
            ReloadSettings();
        }

        private void RemoveButton_Click(object sender, EventArgs e)
        {
            // If there is nothing selected, return
            if (ResourcesListBox.SelectedItem == null)
            {
                return;
            }

            // Now, remove the selected item
            Program.Config.Repos.RemoveAt(ResourcesListBox.SelectedIndex);
            // Save the existing settings
            Program.Config.Save();
            // And reload the settings on the UI
            ReloadSettings();
        }

        #endregion

        #region Bottom

        private void ResetSettingsButton_Click(object sender, EventArgs e)
        {
            // Ask the user if he is sure
            DialogResult Result = MessageBox.Show("Are you sure that you want to reset the settings?", "Resetting Settings", MessageBoxButtons.YesNo);

            // If the user is sure
            if (Result == DialogResult.Yes)
            {
                // Reset the settings
                Program.Config = Configuration.Regenerate();
                // And reload them
                ReloadSettings();
            }
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            // Just close the form
            Close();
        }

        #endregion
    }
}
