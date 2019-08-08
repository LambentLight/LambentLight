using LambentLight.Properties;
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
        private static int Main()
        {
            // If a settings upgrade is required
            if (Settings.Default.UpgradeRequired)
            {
                // Upgrade the settings
                Settings.Default.Upgrade();
                // Store a bool so we know that we have upgraded
                Settings.Default.UpgradeRequired = false;
                // And save the new settings
                Settings.Default.Save();
            }
            // Enable the visual styles for the application
            Application.EnableVisualStyles();
            // Use the classic rendering for compatibility
            Application.SetCompatibleTextRenderingDefault(false);

            // If the program is running on macOS, notify the user and exit
            if (Checks.IsMacOS)
            {
                MessageBox.Show("macOS is not supported by either LambentLight or FiveM!\nThe application will now close.");
                return 2;
            }
            // If we are running Linux, tell the user that only Ubuntu has been tested
            if (Checks.IsLinux)
            {
                MessageBox.Show("Thanks for using LambentLight on Linux!\nPlease note that the only distro that has been tested is Ubuntu.\nIf you find any bugs, please report them. Thanks!");
            }

            // Create our main form
            Form = new Landing();
            // Prepare the downloader for our operations
            Downloader.Prepare();
            // And run the application with our main form
            Application.Run(Form);
            // Once we are back, return a code 0
            return 0;
        }
    }
}
