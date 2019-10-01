using LambentLight.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LambentLight
{
    public partial class Config : Form
    {
        public Config()
        {
            InitializeComponent();
        }
               
        private void ReloadSettings()
        {
            // Disable the license check box
            LicenseVisibleCheckBox.Checked = false;
            SteamVisibleCheckBox.Checked = false;
            
            // And load all of the settings
            DownloadScriptsCheckBox.Checked = Settings.Default.DownloadScripts;
            CreateConfigCheckBox.Checked = Settings.Default.CreateConfig;
            AddToConfigCheckBox.Checked = Settings.Default.AddToConfig;
            RemoveFromConfigCheckBox.Checked = Settings.Default.RemoveFromConfig;

            RestartEveryCheckBox.Checked = Settings.Default.RestartEvery;
            RestartAtCheckBox.Checked = Settings.Default.RestartAt;
            RestartEveryTextBox.Text = Settings.Default.RestartEveryTime.ToString();
            RestartAtTextBox.Text = Settings.Default.RestartAtTime.ToString();

            BuildsWinTextBox.Text = Settings.Default.BuildsWindows;
            BuildsLinTextBox.Text = Settings.Default.BuildsLinux;
            ResourcesTextBox.Text = Settings.Default.Resources;

            AutoRestartCheckBox.Checked = Settings.Default.AutoRestart;
            ClearCacheCheckBox.Checked = Settings.Default.ClearCache;
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
            LicenseTextBox.Text = LicenseVisibleCheckBox.Checked ? Settings.Default.License : string.Empty;
        }

        private void SteamVisibleCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            // Change the enabled status of the Steam TextBox and Button
            SteamTextBox.Enabled = SteamVisibleCheckBox.Checked;
            SteamSaveButton.Enabled = SteamVisibleCheckBox.Checked;
            // And populate the API Key correctly
            SteamTextBox.Text = SteamVisibleCheckBox.Checked ? Settings.Default.SteamAPI : string.Empty;
        }

        private void LicenseGenerateButton_Click(object sender, EventArgs e)
        {
            // Open the FiveM Keymaster page
            Process.Start("https://keymaster.fivem.net");
        }

        private void LicenseSaveButton_Click(object sender, EventArgs e)
        {
            // Save the license on the text box
            Settings.Default.License = LicenseTextBox.Text;
            Settings.Default.Save();
        }

        private void SaveSteamButton_Click(object sender, EventArgs e)
        {
            // Save the Steam API on the text box
            Settings.Default.SteamAPI = SteamTextBox.Text;
            Settings.Default.Save();
        }

        private void SaveAPIsButton_Click(object sender, EventArgs e)
        {
            // Save the URLs on the configuration
            Settings.Default.Resources = ResourcesTextBox.Text;
            Settings.Default.BuildsWindows = BuildsWinTextBox.Text;
            Settings.Default.BuildsLinux = BuildsLinTextBox.Text;
            Settings.Default.Save();
        }

        private void DownloadScriptsCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            // Save the curent status on the settings
            Settings.Default.DownloadScripts = DownloadScriptsCheckBox.Checked;
            Settings.Default.Save();
        }

        private void CreateConfigCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            // Save the curent status on the settings
            Settings.Default.CreateConfig = CreateConfigCheckBox.Checked;
            Settings.Default.Save();
        }

        private void AddToConfigCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            // Save the curent status on the settings
            Settings.Default.AddToConfig = AddToConfigCheckBox.Checked;
            Settings.Default.Save();
        }

        private void RemoveFromConfigCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            // Save the curent status on the settings
            Settings.Default.RemoveFromConfig = RemoveFromConfigCheckBox.Checked;
            Settings.Default.Save();
        }

        private void AutoRestartCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            // Save the curent status on the settings
            Settings.Default.AutoRestart = AutoRestartCheckBox.Checked;
            Settings.Default.Save();
        }

        private void ClearCacheCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            // Save the curent status on the settings
            Settings.Default.ClearCache = ClearCacheCheckBox.Checked;
            Settings.Default.Save();
        }

        private void RestartEveryCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            // Save the curent status on the settings
            Settings.Default.RestartEvery = RestartEveryCheckBox.Checked;
            Settings.Default.Save();
        }

        private void RestartAtCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            // Save the curent status on the settings
            Settings.Default.RestartAt = RestartAtCheckBox.Checked;
            Settings.Default.Save();
        }

        private void RestartEveryButton_Click(object sender, EventArgs e)
        {
            // Try to parse the text box contents
            try
            {
                Settings.Default.RestartEveryTime = TimeSpan.Parse(RestartEveryTextBox.Text);
            }
            // If we have failed
            catch (FormatException)
            {
                MessageBox.Show("The format for the 'Restart every' time is invalid.");
                return;
            }
            // If we succeeded, save it
            Settings.Default.Save();
        }

        private void RestartAtButton_Click(object sender, EventArgs e)
        {
            // Try to parse the text box contents
            try
            {
                Settings.Default.RestartAtTime = TimeSpan.Parse(RestartAtTextBox.Text);
            }
            // If we have failed
            catch (FormatException)
            {
                MessageBox.Show("The format for the 'Restart daily at' time is invalid.");
                return;
            }
            // If we succeeded, save it
            Settings.Default.Save();
        }

        private void ResetSettingsButton_Click(object sender, EventArgs e)
        {
            // Ask the user if he is sure
            DialogResult Result = MessageBox.Show("Are you sure that you want to reset the settings?", "Resetting Settings", MessageBoxButtons.YesNo);

            // If the user is sure
            if (Result == DialogResult.Yes)
            {
                // Reset the settings
                Settings.Default.Reset();
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
