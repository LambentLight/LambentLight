using LambentLight.Config;
using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace LambentLight
{
    public partial class Configurator : Form
    {
        public Configurator()
        {
            InitializeComponent();
        }
               
        private void ReloadSettings()
        {
            // Disable the license check box
            LicenseVisibleCheckBox.Checked = false;
            SteamVisibleCheckBox.Checked = false;
            
            // And load all of the settings
            DownloadScriptsCheckBox.Checked = Program.Config.Creator.DownloadScripts;
            CreateConfigCheckBox.Checked = Program.Config.Creator.CreateConfig;
            AddToConfigCheckBox.Checked = Program.Config.AddAfterInstalling;
            RemoveFromConfigCheckBox.Checked = Program.Config.RemoveAfterUninstalling;

            RestartEveryCheckBox.Checked = Program.Config.AutoRestart.Cron;
            RestartAtCheckBox.Checked = Program.Config.AutoRestart.Daily;
            RestartEveryTextBox.Text = Program.Config.AutoRestart.CronTime.ToString();
            RestartAtTextBox.Text = Program.Config.AutoRestart.DailyTime.ToString();

            /*
            BuildsWinTextBox.Text = Settings.Default.BuildsWindows;
            BuildsLinTextBox.Text = Settings.Default.BuildsLinux;
            ResourcesTextBox.Text = Settings.Default.Resources;
            */

            AutoRestartCheckBox.Checked = Program.Config.RestartOnCrash;
            ClearCacheCheckBox.Checked = Program.Config.ClearCache;
        }

        private void Config_Load(object sender, EventArgs e)
        {
            // Load the settings
            ReloadSettings();
        }

        private void LicenseVisibleCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            // Change the enabled status of the License TextBox and Button
            LicenseTextBox.Enabled = LicenseVisibleCheckBox.Checked;
            LicenseSaveButton.Enabled = LicenseVisibleCheckBox.Checked;
            // And populate the License correctly
            LicenseTextBox.Text = LicenseVisibleCheckBox.Checked ? Program.Config.CFXToken : string.Empty;
        }

        private void SteamVisibleCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            // Change the enabled status of the Steam TextBox and Button
            SteamTextBox.Enabled = SteamVisibleCheckBox.Checked;
            SteamSaveButton.Enabled = SteamVisibleCheckBox.Checked;
            // And populate the API Key correctly
            SteamTextBox.Text = SteamVisibleCheckBox.Checked ? Program.Config.SteamToken : string.Empty;
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

        private void SaveAPIsButton_Click(object sender, EventArgs e)
        {
            /*
            // Save the URLs on the configuration
            Settings.Default.Resources = ResourcesTextBox.Text;
            Settings.Default.BuildsWindows = BuildsWinTextBox.Text;
            Settings.Default.BuildsLinux = BuildsLinTextBox.Text;
            Settings.Default.Save();
            */
        }

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

        private void AutoRestartCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            // Save the curent status on the settings
            Program.Config.RestartOnCrash = AutoRestartCheckBox.Checked;
            Program.Config.Save();
        }

        private void ClearCacheCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            // Save the curent status on the settings
            Program.Config.ClearCache = ClearCacheCheckBox.Checked;
            Program.Config.Save();
        }

        private void RestartEveryCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            // Save the curent status on the settings
            Program.Config.AutoRestart.Cron = RestartEveryCheckBox.Checked;
            Program.Config.Save();
        }

        private void RestartAtCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            // Save the curent status on the settings
            Program.Config.AutoRestart.Daily = RestartAtCheckBox.Checked;
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
    }
}
