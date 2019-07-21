using NLog;
using NLog.Config;
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
    public partial class Landing : Form
    {
        public Landing()
        {
            // Initialize the UI elements
            InitializeComponent();
            // Create a new configuration for NLog
            LoggingConfiguration NewConfig = new LoggingConfiguration();
            // Add a rule for logging to the TextBox
            NewConfig.AddRule(LogLevel.Info, LogLevel.Fatal, new TextBoxTarget() { Box = LogBox, Layout = "[${date}] [${level}] [${logger}] ${message}" });
            // Set the already created configuration
            LogManager.Configuration = NewConfig;
            // And filll the Builds and Data folders
            BuildManager.Fill(BuildsBox);
            DataFolderManager.Fill(DataBox);
        }

        private async void StartItem_Click(object sender, EventArgs e)
        {
            // Start the build with the selected options
            await ServerManager.Start((Build)BuildsBox.SelectedItem, (DataFolder)DataBox.SelectedItem);
        }

        private async void StopItem_Click(object sender, EventArgs e)
        {
            // Stop the server if is present
            await ServerManager.Stop();
        }

        private async void CreateItem_Click(object sender, EventArgs e)
        {
            // Ask the user for inputing a server data folder name
            string FolderName = Microsoft.VisualBasic.Interaction.InputBox("Please insert a name for the new Server Data Folder:", "New Server Data Folder");
            // Create a server data folder
            await DataFolderManager.Create(FolderName);
        }

        private void ExitItem_Click(object sender, EventArgs e)
        {
            // Close the current form
            Close();
        }
    }
}
