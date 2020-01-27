using LambentLight.Config;
using LambentLight.Managers.Database;
using LambentLight.Targets;
using Nancy.Hosting.Self;
using NLog;
using NLog.Config;
using System;
using System.Windows.Forms;

namespace LambentLight
{
    public static class Program
    {
        #region Internal Fields

        /// <summary>
        /// The mod/program configuration.
        /// </summary>
        internal static Configuration Config = Configuration.Load();

        #endregion

        #region Public Properties

        /// <summary>
        /// The main form of our application.
        /// </summary>
        public static FormLanding Form { get; private set; }
        /// <summary>
        /// The Nancy Web Server.
        /// </summary>
        public static NancyHost WebServer = new NancyHost(new Uri("http://127.0.0.1:42069"));

        #endregion

        #region Main

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        private static int Main()
        {
            // Enable the visual styles for the application
            Application.EnableVisualStyles();
            // Use GDI+ for rendering instead of GDI
            Application.SetCompatibleTextRenderingDefault(false);

            // Create our main form
            Form = new FormLanding();

            // Create a new configuration for NLog
            LoggingConfiguration config = new LoggingConfiguration();
            // Add new rules for logging into the Console and Strip at the Bottom
            config.AddRule(LogLevel.Debug, LogLevel.Fatal, new TextBoxTarget() { Layout = "[${date}] [${level}] ${message}" });
            config.AddRule(LogLevel.Info, LogLevel.Fatal, new BottomStripTarget() { Layout = "${message}" });
            // And make NLog use this new configuration
            LogManager.Configuration = config;

            // Try to connect into the MySQL database
            DatabaseManager.Connect();

            // Prepare the downloader for our operations
            Downloader.Prepare();
            // Start the web server
            WebServer.Start();
            // And run the application with our main form
            Application.Run(Form);
            // Once we are back, return a code 0
            return 0;
        }

        #endregion
    }
}
