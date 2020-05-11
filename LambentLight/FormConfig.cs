using System;
using System.Windows.Forms;

namespace LambentLight
{
    public partial class FormConfig : Form
    {
        #region Constructor

        public FormConfig()
        {
            InitializeComponent();
        }

        #endregion

        #region Tools

        /// <summary>
        /// Loads the program settings on the UI.
        /// </summary>
        public void Populate()
        {
            // Authentication
            CFXTextBox.Text = Program.Config.CFXLicense;
            SteamTextBox.Text = Program.Config.SteamKey;
        }
        /// <summary>
        /// Saves the settings.
        /// </summary>
        public void Save()
        {
            // Authentication
            Program.Config.CFXLicense = CFXTextBox.Text;
            Program.Config.SteamKey = SteamTextBox.Text;

            Program.Config.Save();
        }

        #endregion

        #region Authentication

        private void CFXVisibleCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            CFXTextBox.UseSystemPasswordChar = !CFXVisibleCheckBox.Checked;
        }

        private void SteamVisibleCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            SteamTextBox.UseSystemPasswordChar = !SteamVisibleCheckBox.Checked;
        }

        #endregion

        #region Buttons

        private void SaveButton_Click(object sender, EventArgs e)
        {
            Save();
            Close();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        #endregion
    }
}
