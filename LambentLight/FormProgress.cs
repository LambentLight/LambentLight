using Serilog;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LambentLight
{
    /// <summary>
    /// Form used to show the progress of something.
    /// </summary>
    public partial class FormProgress : Form
    {
        /// <summary>
        /// The type of task to use in the progress form.
        /// </summary>
        private enum TaskType
        {
            Invalid = -1,
            Initialization = 0,
            Download = 1,
            Extraction = 2
        }

        /// <summary>
        /// The type of task that this form should perform.
        /// </summary>
        private TaskType task = TaskType.Invalid;
        /// <summary>
        /// If this task has been completed or not.
        /// </summary>
        private bool finished = false;

        private FormProgress()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Creates a progress form to perform the program initialization.
        /// </summary>
        /// <returns></returns>
        public static FormProgress Initialization()
        {
            return new FormProgress
            {
                task = TaskType.Initialization
            };
        }

        private async void FormInit_Shown(object sender, EventArgs e)
        {
            switch (task)
            {
                case TaskType.Initialization:
                    await PerformInitialization();
                    return;
                default:
                    throw new InvalidOperationException($"Task of type {task} is invalid.");
            }
        }

        private async Task PerformInitialization()
        {
            Log.Information("Performing initialization of managers");
            // Set the maximum value
            InitProgressBar.Maximum = 2;

            // Initialize the managers
            // Build Manager
            LabelTask.Text = "Populating Data Folders";
            await Managers.FolderManager.Initialize();
            InitProgressBar.PerformStep();
            // Build Manager
            LabelTask.Text = "Populating CFX Builds";
            await Managers.BuildManager.Initialize();
            InitProgressBar.PerformStep();

            // And close the form
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
