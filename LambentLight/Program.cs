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
            // Prepare the downloader for our operations
            Downloader.Prepare();
            // And run the application with our main form
            Application.Run(Form);
        }
    }
}
