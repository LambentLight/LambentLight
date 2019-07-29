using System;
using System.Net;
using System.Windows.Forms;

namespace LambentLight
{
    public static class Program
    {
        /// <summary>
        /// The main form of our application.
        /// </summary>
        public static Landing Form;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // If a settings upgrade is required
            if (Properties.Settings.Default.UpgradeRequired)
            {
                // Upgrade the settings
                Properties.Settings.Default.Upgrade();
                // Store a bool so we know that we have upgraded
                Properties.Settings.Default.UpgradeRequired = false;
                // And save the new settings
                Properties.Settings.Default.Save();
            }
            // Enable the visual styles for the application
            Application.EnableVisualStyles();
            // Use the classic rendering for compatibility
            Application.SetCompatibleTextRenderingDefault(false);
            // Create our main form
            Form = new Landing();
            // And run the application with our main form
            Application.Run(Form);
        }

        /// <summary>
        /// Event that gets triggered when the download progress of a file changes.
        /// </summary>
        public static void OnDownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            // Calculate the percentage of the download
            int Percentage = (int)((float)e.BytesReceived / e.TotalBytesToReceive * 100f);

            // Make a sanity check to ensure that the percentage is on the correct location
            if (Percentage >= Form.MainProgressBar.Minimum && Percentage <= Form.MainProgressBar.Maximum)
            {
                // And set the value of the progress bar
                Form.MainProgressBar.Value = Percentage;
            }
        }
    }
}
