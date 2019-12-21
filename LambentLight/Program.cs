using LambentLight.Config;
using System;
using System.Net;
using System.Windows.Forms;

namespace LambentLight
{
    public static class Program
    {
        /// <summary>
        /// The mod configuration.
        /// </summary>
        internal static Configuration Config = Configuration.Load();
        /// <summary>
        /// The main form of our application.
        /// </summary>
        public static FormLanding Form;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        private static int Main()
        {
            // Enable the visual styles for the application
            Application.EnableVisualStyles();
            // Use the classic rendering for compatibility
            Application.SetCompatibleTextRenderingDefault(false);

            // Create our main form
            Form = new FormLanding();
            // Prepare the downloader for our operations
            Downloader.Prepare();
            // And run the application with our main form
            Application.Run(Form);
            // Once we are back, return a code 0
            return 0;
        }
    }
}
