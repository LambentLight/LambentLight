using System;
using System.Windows.Forms;

namespace ServerManager
{
    public partial class Landing : Form
    {
        public Landing()
        {
            InitializeComponent();
        }

        private void OpenSettings_Click(object sender, EventArgs e)
        {
            Settings SettingsWindow = new Settings();
            SettingsWindow.ShowDialog();
        }
    }
}
