using LambentLight.Managers;
using LambentLight.Properties;
using System;
using System.Windows.Forms;

namespace LambentLight
{
    public partial class Creator : Form
    {
        /// <summary>
        /// The new data folder that should be created.
        /// </summary>
        public DataFolder NewDataFolder { get; set; } = null;

        public Creator()
        {
            // Initialize the UI elements
            InitializeComponent();
        }

        private void SaveOptions()
        {
            // Just save the settings
            Program.Config.Creator.DownloadScripts = DownloadCheckBox.Checked;
            Program.Config.Creator.SHVEnabled = SHVCheckBox.Checked;
            Program.Config.Save();
        }

        private void LoadOptions()
        {
            // Oposite to the function above
            DownloadCheckBox.Checked = Program.Config.Creator.DownloadScripts;
            SHVCheckBox.Checked = Program.Config.Creator.SHVEnabled;
        }

        private void Creator_Load(object sender, EventArgs e)
        {
            LoadOptions();
        }

        private void CreateButton_Click(object sender, EventArgs e)
        {
            // If the name is null or empty
            if (string.IsNullOrWhiteSpace(NameTextBox.Text))
            {
                // Notify the user and return
                MessageBox.Show("Looks like the Folder Name is empty, please check that the name is valid and try again.", "Invalid Name", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Create a new server data folder
            DataFolder folder = new DataFolder(NameTextBox.Text);
            // If the folder does not exists
            if (folder.Exists)
            {
                // Ask the user if he wants to replace it
                if (MessageBox.Show("This Data Folder already exists, do you want to replace it?", "Folder Already Exists", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    // If he does, delete it
                    folder.Dispose();
                }
                // Otherwise, return
                else
                {
                    return;
                }
            }

            // Save it and close the form
            NewDataFolder = folder;
            Close();
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            // Call the existing function to save the settings
            SaveOptions();
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            // Self Explanatory, don't you think?
            Close();
        }

        private void PreviousButton_Click(object sender, EventArgs e)
        {
            // If the selected tab is not zero, set the previous tab
            if (CreatorTabControl.SelectedIndex != 0)
            {
                CreatorTabControl.SelectedIndex -= 1;
            }
        }

        private void NextButton_Click(object sender, EventArgs e)
        {
            // If the selected tab is not over the max, set the next tab
            if (CreatorTabControl.SelectedIndex != CreatorTabControl.TabCount -1)
            {
                CreatorTabControl.SelectedIndex += 1;
            }
        }

        private void CreatorTabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Enable the previous button if the tab is not the first one
            PreviousButton.Enabled = CreatorTabControl.SelectedIndex != 0;
            // Enable the last button if the tab is not the last one
            NextButton.Enabled = CreatorTabControl.SelectedIndex != CreatorTabControl.TabCount - 1;
        }
    }
}
