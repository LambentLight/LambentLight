using Serilog;
using System;
using System.Net;
using System.Windows.Forms;

namespace LambentLight
{
    /// <summary>
    /// Class that stores the basics of the application.
    /// </summary>
    public static class Program
    {
        /// <summary>
        /// The configuration of the application.
        /// </summary>
        public static Configuration Config { get; private set; } = null;
        /// <summary>
        /// The Landing Screen for the program.
        /// </summary>
        public static FormLanding Landing { get; private set; } = null;

        /// <summary>
        /// Main Entry Point of the application.
        /// </summary>
        /// <returns>The exit code of the app.</returns>
        [STAThread]
        public static int Main()
        {
            // Before doing anything, make sure that we use TLS 1.2 instead of SSL 3 for network requests
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            // Set the correct Serilog configuration
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.File("LambentLight.log")
                .WriteTo.Debug()
                .CreateLogger();

            // Try to load the configuration
            Config = Configuration.Load();
            // If is invalid, exit
            if (Config == null)
            {
                return 1;
            }

            // Enable the Vista+ visual styles and GDI+
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            // Create the forms
            Landing = new FormLanding();
            // And run the app with the default form
            Application.Run(Landing);

            // Once we have finished, terminate the logger and exit
            Log.CloseAndFlush();
            return 0;
        }
    }
}
