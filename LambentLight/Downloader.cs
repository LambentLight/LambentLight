using Newtonsoft.Json;
using NLog;
using System;
using System.Net;
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
        /// Prepares the client for the web requests.
        /// </summary>
        public static void Prepare()
        {
            // Set the event to refresh the progress bar
            Client.DownloadProgressChanged += OnDownloadProgressChanged;

            // Tell the Web Clients to use TLS 1.2 instead of SSL3
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            // Get the name and version of the current program
            string name = System.Reflection.Assembly.GetExecutingAssembly().GetName().Name;
            string version = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();
            Client.Headers["User-Agent"] = $"{name}/{version} (+https://github.com/LambentLight/LambentLight)";
        }

        /// <summary>
        /// Downloads a file from the specified URL.
        /// </summary>
        /// <param name="from">The URL to download from.</param>
        /// <param name="to">The file to download to.</param>
        /// <ret
        public static async Task<bool> DownloadFile(string from, string to)
        {
            // Try to download the file
            try
            {
                await Client.DownloadFileTaskAsync(from, to);
            }
            // If we got a HTTP exception
            catch (WebException e)
            {
                Logger.Error("Error while downloading '{0}': {1}", from, e.Message);
                return false;
            }
            // Reset the progress of the health bar
            Program.Form.GeneralProgressBar.Value = 0;
            // Return that we have succeeded
            return true;
        }

        /// <summary>
        /// Requests a URL as a string.
        /// </summary>
        /// <param name="from">The URL to fetch.</param>
        /// <returns>The contents of the response if the request succeeded, null otherwise.</returns>
        public static string DownloadString(string from)
        {
            // Try to download the string
            try
            {
                // Use the asynchronous method
                string Output = Client.DownloadString(from);
                // Reset the progress bar
                Program.Form.GeneralProgressBar.Value = 0;
                // And return our string
                return Output;
            }
            // If we got a HTTP exception
            catch (WebException er)
            {
                Logger.Error("Error while fetching '{0}': {1}", from, er.Message);
                return null;
            }
            // If one of the arguments is invalid
            catch (ArgumentException er)
            {
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
            // NOTE: This solution can't be built on AppVeyor under the VS 2019 image, so use default(T) for the time being

            // Request the string as usual
            string Contents = DownloadString(from);
            // If the content is not null
            if (Contents != null)
            {
                // Try to parse the JSON
                try
                {
                    return JsonConvert.DeserializeObject<T>(Contents, converters);
                }
                // If we have failed, return the default value
                catch (EntryPointNotFoundException)
                {
                    return default(T);
                }
            }
            // If the HTTP request failed, return null
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
