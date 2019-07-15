using System;
using System.IO;
using System.Windows.Forms;

namespace LambentLight
{
    public partial class Editor : Form
    {
        /// <summary>
        /// The location of the file.
        /// </summary>
        public readonly string FileLocation;

        public Editor(string FileLocation)
        {
            // Store the file
            this.FileLocation = FileLocation;
            // Initialize the UI
            InitializeComponent();
            // Open the file and read the contents
            TextField.Text = File.ReadAllText(FileLocation);
        }

        private void SaveFile_Click(object sender, EventArgs e)
        {
            // Write all of the text to the file
            File.WriteAllText(FileLocation, TextField.Text);
            Close();
        }

        private void ReloadFile_Click(object sender, EventArgs e)
        {
            // Open the file and read the contents
            TextField.Text = File.ReadAllText(FileLocation);
        }
    }
}
