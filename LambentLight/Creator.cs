using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LambentLight
{
    public partial class Creator : Form
    {
        /// <summary>
        /// If the Data Folder should be created after exiting the form.
        /// </summary>
        public bool ShouldBeCreated { get; set; } = false;

        public Creator()
        {
            // Initialize the UI elements
            InitializeComponent();
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

            // Save that the Data Folder should be created
            ShouldBeCreated = true;
            // And close the form
            Close();
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {

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
