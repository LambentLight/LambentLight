using Serilog;
using SharpCompress.Archives;
using SharpCompress.Common;
using SharpCompress.Readers;
using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LambentLight
{
    /// <summary>
    /// Form used to show the progress of something.
    /// </summary>
    public partial class FormProgress : Form
    {
        #region Task Type

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

        #endregion

        #region Properties

        /// <summary>
        /// If the task has been completed successfully.
        /// </summary>
        public bool Completed { get; private set; } = false;

        #endregion

        #region Fields - Common

        /// <summary>
        /// If this task has been completed or not.
        /// </summary>
        private bool finished = false;

        #endregion

        #region Fields - Download

        /// <summary>
        /// The URL to download a file from.
        /// </summary>
        private string url = "";
        /// <summary>
        /// The path of a folder to store the file.
        /// </summary>
        private string path = "";
        /// <summary>
        /// The name of the file.
        /// </summary>
        private string filename = "";

        #endregion

        #region Fields - Extraction

        /// <summary>
        /// The options used to extract the files.
        /// </summary>
        private static readonly ExtractionOptions options = new ExtractionOptions() { ExtractFullPath = true };
        /// <summary>
        /// The file to extract.
        /// </summary>
        private string file = "";
        /// <summary>
        /// The desired extraction location.
        /// </summary>
        private string destination = "";

        #endregion

        #region Constructor

        private FormProgress()
        {
            InitializeComponent();
        }

        #endregion

        #region Public Functions

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

        /// <summary>
        /// Creates a progress form to perform a file download.
        /// </summary>
        /// <param name="url">The URL of the file.</param>
        /// <param name="path">The target directory.</param>
        /// <param name="filename">The name of the file.</param>
        /// <returns></returns>
        public static FormProgress Download(string url, string path, string filename)
        {
            return new FormProgress
            {
                task = TaskType.Download,
                url = url,
                path = path,
                filename = filename
            };
        }

        /// <summary>
        /// Creates a progress form to extract a compressed file.
        /// </summary>
        /// <param name="file">The file to extract.</param>
        /// <param name="destination">The destination of the files.</param>
        /// <returns></returns>
        public static FormProgress Extract(string file, string destination)
        {
            return new FormProgress
            {
                task = TaskType.Extraction,
                file = file,
                destination = destination
            };
        }

        #endregion

        #region Local Events

        private async void FormInit_Shown(object sender, EventArgs e)
        {
            switch (task)
            {
                case TaskType.Initialization:
                    await PerformInitialization();
                    break;
                case TaskType.Download:
                    await PerformDownload();
                    break;
                case TaskType.Extraction:
                    await PerformExtraction();
                    break;
                default:
                    throw new InvalidOperationException($"Task of type {task} is invalid.");
            }

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

        #endregion

        #region Private Functions

        private async Task PerformInitialization()
        {
            Log.Information("Performing initialization of managers");
            // Configure the UI
            Text = "Initializing...";
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

            // And say that we succeded
            Completed = true;
        }

        private async Task PerformDownload()
        {
            // We use WebClient directly because Flurl does not supports file downloads

            Log.Information($"Downloading {url} to {path} as {filename}");
            Text = "Downloading...";
            InitProgressBar.Maximum = 100;
            LabelTask.Text = filename;

            using (WebClient client = new WebClient())
            {
                client.DownloadProgressChanged += (s, e) => Invoke(new Action(() => InitProgressBar.Value = e.ProgressPercentage)); ;

                try
                {
                    await client.DownloadFileTaskAsync(url, Path.Combine(path, filename));
                    Completed = true;
                }
                catch (WebException e)
                {
                    Log.Error(e, $"Unable to download {url}");
                    MessageBox.Show($"Unable to download {url}\n\nMake sure that you are connected to the internet and LambentLight is allowed on your system firewall.", "Unable to download file", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
        }

        private async Task PerformExtraction()
        {
            Log.Information($"Extracting {file} to {destination}");
            Text = "Extracting...";

            using (IArchive archive = ArchiveFactory.Open(file))
            {
                InitProgressBar.Maximum = archive.Entries.Count();

                IReader reader = archive.ExtractAllEntries();

                while (reader.MoveToNextEntry())
                {
                    if (!reader.Entry.IsDirectory)
                    {
                        LabelTask.Text = reader.Entry.Key;
                        InitProgressBar.PerformStep();
                        try
                        {
                            await Task.Run(() => reader.WriteEntryToDirectory(destination, options));
                        }
                        catch (UnauthorizedAccessException e)
                        {
                            Log.Error(e, $"Unable to extract {reader.Entry.Key}");
                            MessageBox.Show($"Unable to extract {reader.Entry.Key}\n\nMake sure that your Windows user is allowed to write into {destination} and try again.", "Unable to extract file", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                }
            }

            Completed = true;
        }

        #endregion
    }
}
