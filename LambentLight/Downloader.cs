using Newtonsoft.Json;
using NLog;
using System;
using System.Net;
using System.Reflection;
using System.Threading.Tasks;

namespace LambentLight
{
    public static class Downloader
    {
        #region Private Fields

        /// <summary>
        /// The logger for our current class.
        /// </summary>
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();
        /// <summary>
        /// The client to use for web requests.
        /// </summary>
        private static readonly WebClient Client = new WebClient();

        #endregion

        #region Public Functions

        /// <summary>
        /// Prepares the Web Client with the correct Protocol and Headers.
        /// </summary>
        public static void Prepare()
        {
            // Subscibe the event that changes the progress bar value
            Client.DownloadProgressChanged += OnDownloadProgressChanged;

            // Tell the client to use TLS 1.2 instead of SSL3
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            // Get the name and version of the current program
            string name = Assembly.GetExecutingAssembly().GetName().Name;
            string version = Assembly.GetExecutingAssembly().GetName().Version.ToString();
            // And set them as the User-Agent header
            Client.Headers["User-Agent"] = $"{name}/{version} (+https://github.com/LambentLight/LambentLight)";
        }

        /// <summary>
        /// Downloads a file.
        /// </summary>
        /// <param name="from">The URL of the file.</param>
        /// <param name="to">The location where the file should be downloaded.</param>
        /// <returns>true if the operation succeeded, false otherwise.</returns>
        public static async Task<bool> DownloadFile(string from, string to)
        {
            try
            {
                // Try to download the file
                await Client.DownloadFileTaskAsync(from, to);
                // After downloading the file, reset the ProgressBar Value
                Program.Form.GeneralProgressBar.Value = 0;
                // And show that the operation was successful
                return true;
            }
            catch (WebException e)
            {
                // If we got a HTTP exception, log it and return
                Logger.Error("Error while downloading '{0}': {1}", from, e.Message);
                return false;
            }
        }

        /// <summary>
        /// Downloads the content of a URL.
        /// </summary>
        /// <param name="from">The URL to fetch.</param>
        /// <returns>The contents of the response if the request succeeded, null otherwise.</returns>
        public static string DownloadString(string from)
        {
            try
            {
                // Try to fetch the string from the URL
                string output = Client.DownloadString(from);
                // After fetching the string, reset the ProgressBar Value
                Program.Form.GeneralProgressBar.Value = 0;
                // And return the string
                return output;
            }
            catch (WebException er)
            {
                // If we got a HTTP exception, log it and return
                Logger.Error("Error while fetching '{0}': {1}", from, er.Message);
                return null;
            }
            catch (ArgumentException er)
            {
                // If one of the arguments is invalid, log it and return
                Logger.Error("Error while fetching '{0}': {1}", from, er.Message);
                return null;
            }
        }

        /// <summary>
        /// Requests the JSON from the URL and parses it.
        /// </summary>
        /// <typeparam name="T">The output type to parse.</typeparam>
        /// <param name="from">The URL to fetch.</param>
        /// <param name="converters">Aditional JSON converters to use.</param>
        /// <returns>The parsed contents if the request and parsing succeeds, default(T) otherwise.</returns>
        public static T DownloadJSON<T>(string from, params JsonConverter[] converters)
        {
            // Request the string as usual
            string contents = DownloadString(from);

            // If the content is not null
            if (contents != null)
            {
                // Try to deserialize the JSON into a .NET Object
                try
                {
                    return JsonConvert.DeserializeObject<T>(contents, converters);
                }
                // If we failed, return the default value
                catch (EntryPointNotFoundException)
                {
                    return default(T);
                }
            }

            // If the HTTP request failed, return the default value
            return default(T);
        }

        #endregion

        #region Events

        /// <summary>
        /// Event that gets triggered when the download progress of a file changes.
        /// </summary>
        private static void OnDownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            // Calculate the percentage of the download
            int Percentage = (int)((float)e.BytesReceived / e.TotalBytesToReceive * 100f);

            // Make a sanity check to ensure that the percentage is on the correct location
            if (Percentage >= Program.Form.GeneralProgressBar.Minimum && Percentage <= Program.Form.GeneralProgressBar.Maximum)
            {
                // And set the value of the progress bar
                Program.Form.GeneralProgressBar.Value = Percentage;
            }
        }

        #endregion
    }
}
