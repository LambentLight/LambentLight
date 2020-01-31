using LambentLight.Config;
using LambentLight.Managers.Database;
using LambentLight.Targets;
using Nancy.Hosting.Self;
using NLog;
using NLog.Config;
using System;
using System.Net;
using System.Reflection;
using System.Security.Cryptography;
using System.Windows.Forms;

namespace LambentLight
{
    public static class Program
    {
        #region Internal Fields

        /// <summary>
        /// The logger for our current class.
        /// </summary>
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();
        /// <summary>
        /// The secure Random Number Generator for RCON passwords.
        /// </summary>
        private static readonly RNGCryptoServiceProvider RNG = new RNGCryptoServiceProvider();
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
        public static NancyHost WebServer { get; private set; } = null;
        /// <summary>
        /// The version as a string of the current executable.
        /// </summary>
        public static string Version => Assembly.GetExecutingAssembly().GetName().Version.ToString();

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

            // Use TLS 1.2 instead of SSL3 for all web requests
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

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

            // If the web server is enabled
            if (Config.API.Enabled)
            {
                // Just try to process it inside of a try
                try
                {
                    // Try to create the Uri and server object
                    Uri uri = new Uri(Config.API.BindTo);
                    WebServer = new NancyHost(uri);
                    // Start the server
                    WebServer.Start();
                    // And log it
                    Logger.Info($"LambentLight Web Server started at {Config.API.BindTo}");
                }
                // If Nancy failed to bind the URL
                catch (AutomaticUrlReservationCreationFailureException)
                {
                    Logger.Error("Unable to reserve the URL for the REST API, make sure that the URL and Port are correct and try again");
                }
                // If the format of the URL is invalid
                catch (UriFormatException)
                {
                    Logger.Error($"The bind address for the REST API is invalid!");
                }
            }

            // And run the application with our main form
            Application.Run(Form);
            // Once we are back, return a code 0
            return 0;
        }

        #endregion

        #region Tools

        public static string GenerateSecureString(int size = 32)
        {
            // Create a place to store the output
            byte[] randomBytes = new byte[size];
            // Create the random string as bytes
            RNG.GetBytes(randomBytes);
            // And then, return that byte array as a string
            return Convert.ToBase64String(randomBytes);
        }

        #endregion
    }
}
