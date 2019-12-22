using LambentLight.Managers.DataFolders;
using System;
using System.Windows.Forms;

namespace LambentLight
{
    public partial class FormCreator : Form
    {
        #region Public Properties

        /// <summary>
        /// The new data folder that is going to be created.
        /// </summary>
        public DataFolder NewDataFolder { get; private set; } = null;

        #endregion

        #region Constructors and Loading

        public FormCreator()
        {
            // Initialize the UI elements
            InitializeComponent();
        }

        private void Creator_Load(object sender, EventArgs e)
        {
            // Load the options from the configuration
            LoadOptions();
        }

        #endregion

        #region Tools

        private void SaveOptions()
        {
            // Save the settings from the UI Elements
            Program.Config.Creator.DownloadScripts = DownloadCheckBox.Checked;
            Program.Config.Creator.SHVEnabled = SHVCheckBox.Checked;
            Program.Config.Save();
        }

        private void LoadOptions()
        {
            // Set the values of the UI Elements from the configuration
            DownloadCheckBox.Checked = Program.Config.Creator.DownloadScripts;
            SHVCheckBox.Checked = Program.Config.Creator.SHVEnabled;
        }

        #endregion

        #region Tab Change Event

        private void CreatorTabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Enable the previous button if the tab is not the first one
            PreviousButton.Enabled = CreatorTabControl.SelectedIndex != 0;
            // Enable the last button if the tab is not the last one
            NextButton.Enabled = CreatorTabControl.SelectedIndex != CreatorTabControl.TabCount - 1;
        }

        #endregion

        #region Buttons at the Bottom

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

            // If a folder with the same name already exists
            if (folder.Exists)
            {
                // Ask the user if he wants to replace it
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

            // Finally, save the new folder
            NewDataFolder = folder;
            // And close the form
            Close();
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            // Call the existing function to save the settings
            SaveOptions();
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            // Just close this form
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
            // If the selected tab is the last one, set the next tab
            if (CreatorTabControl.SelectedIndex != CreatorTabControl.TabCount - 1)
            {
                CreatorTabControl.SelectedIndex += 1;
            }
        }

        #endregion
    }
}
