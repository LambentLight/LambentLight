using System;
using System.Windows.Forms;

namespace ServerManager
{
    public partial class Settings : Form
    {
        public Settings()
        {
            InitializeComponent();

            License.Text = Properties.Settings.Default.License;
            AutoRestart.Checked = Properties.Settings.Default.AutoRestart;
            ClearCache.Checked = Properties.Settings.Default.ClearCache;
            DownloadScripts.Checked = Properties.Settings.Default.DownloadScripts;
        }

        private void Save_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.License = License.Text;
            Properties.Settings.Default.AutoRestart = AutoRestart.Checked;
            Properties.Settings.Default.ClearCache = ClearCache.Checked;
            Properties.Settings.Default.DownloadScripts = DownloadScripts.Checked;

            Close();
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
