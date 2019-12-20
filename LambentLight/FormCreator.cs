using LambentLight.DataFolders;
using LambentLight.Managers;
using LambentLight.Properties;
using System;
using System.Windows.Forms;

namespace LambentLight
{
    public partial class FormCreator : Form
    {
        /// <summary>
        /// The new data folder that should be created.
        /// </summary>
        public DataFolder NewDataFolder { get; set; } = null;

        public FormCreator()
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
            // If the text is whitespaces or null, notify the user and return
            if (string.IsNullOrWhiteSpace(NameTextBox.Text))
            {
                MessageBox.Show("Looks like the Folder Name is empty, please check that the name is valid and try again.", "Invalid Name", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Create the object for the data folder
            DataFolder folder = new DataFolder(NameTextBox.Text);

            // If the folder does not exists
            if (folder.Exists)
            {
                // Ask the user if he wants to replace the existing folder
                DialogResult result = MessageBox.Show("This Data Folder already exists, do you want to replace it?", "Folder Already Exists", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                // If he does, delete it
                if (result == DialogResult.Yes)
                {
                    folder.Remove();
                }
                // Otherwise, return
                else
                {
                    return;
                }
            }

            // Finally, save it and close the form
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
