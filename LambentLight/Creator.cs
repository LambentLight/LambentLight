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

        }

        private void NextButton_Click(object sender, EventArgs e)
        {

        }
    }
}
