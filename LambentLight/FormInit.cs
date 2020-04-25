using Serilog;
using System;
using System.Windows.Forms;

namespace LambentLight
{
    /// <summary>
    /// Form that initalizes the Managers and other features.
    /// </summary>
    public partial class FormInit : Form
    {
        private bool finished = false;

        public FormInit()
        {
            InitializeComponent();
        }

        private async void FormInit_Shown(object sender, EventArgs e)
        {
            Log.Information("Performing initialization of managers");

            // Build Manager
            LabelTask.Text = "Populating Data Folders";
            await Managers.FolderManager.Initialize();
            InitProgressBar.PerformStep();
            // Build Manager
            LabelTask.Text = "Populating CFX Builds";
            await Managers.BuildManager.Initialize();
            InitProgressBar.PerformStep();

            // Finally, close the form
            finished = true;
            Close();
        }

        private void FormInit_FormClosing(object sender, FormClosingEventArgs e)
        {
            // If the initialization has not finished, prevent the form from being closed
            if (!finished)
            {
                e.Cancel = true;
            }
        }
    }
}
