using System;
using System.Windows.Forms;

namespace LambentLight
{
    public partial class Settings : Form
    {
        public Settings()
        {
            // Initialize the UI
            InitializeComponent();
            // And set the values from the configuration
            License.Text = Properties.Settings.Default.License;
            ResourceDownload.Text = Properties.Settings.Default.Resources;
            BuildsBox.Text = Properties.Settings.Default.Builds;
            AutoRestart.Checked = Properties.Settings.Default.AutoRestart;
            ClearCache.Checked = Properties.Settings.Default.ClearCache;
            DownloadScripts.Checked = Properties.Settings.Default.DownloadScripts;
            ShowConfigOpt.Checked = Properties.Settings.Default.ConfigLine;
            ScheduledRestarts.Checked = Properties.Settings.Default.ScheduledRestart;
            ScheduledMode.SelectedIndex = Properties.Settings.Default.ScheduledMode;
            ScheduledTime.Text = Properties.Settings.Default.ScheduledTime.ToString();
            // Set the status of the controls
            SetScheduledControls(Properties.Settings.Default.ScheduledRestart);
        }

        private void Save_Click(object sender, EventArgs e)
        {
            // Try to parse the time
            try
            {
                TimeSpan.Parse(ScheduledTime.Text);
            }
            catch (FormatException)
            {
                MessageBox.Show("The format for the Scheduled Restart time is invalid.");
                return;
            }

            // Store the values on their respective places
            Properties.Settings.Default.License = License.Text;
            Properties.Settings.Default.Resources = ResourceDownload.Text;
            Properties.Settings.Default.Builds = BuildsBox.Text;
            Properties.Settings.Default.AutoRestart = AutoRestart.Checked;
            Properties.Settings.Default.ClearCache = ClearCache.Checked;
            Properties.Settings.Default.DownloadScripts = DownloadScripts.Checked;
            Properties.Settings.Default.ConfigLine = ShowConfigOpt.Checked;
            Properties.Settings.Default.ScheduledRestart = ScheduledRestarts.Checked;
            Properties.Settings.Default.ScheduledMode = ScheduledMode.SelectedIndex;
            Properties.Settings.Default.ScheduledTime = TimeSpan.Parse(ScheduledTime.Text);
            // Save the configuration
            Properties.Settings.Default.Save();
            // And close the settings window
            Close();
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            // The user just wants to close the window
            Close();
        }

        private void ScheduledRestarts_CheckedChanged(object sender, EventArgs e)
        {
            SetScheduledControls(ScheduledRestarts.Checked);
        }

        private void SetScheduledControls(bool Enabled)
        {
            ScheduledMode.Enabled = Enabled;
            ScheduledTime.Enabled = Enabled;
        }
    }
}
