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

        #endregion

        #region Private Functions

        /// <summary>
        /// Creates a new WebClient object.
        /// </summary>
        /// <returns>The ready to use WebClient.</returns>
        public static WebClient CreateWebClient()
        {
            // Create a new WebClient object
            WebClient client = new WebClient();
            // Set the correct User-Agent header
            string name = Assembly.GetExecutingAssembly().GetName().Name;
            string version = Assembly.GetExecutingAssembly().GetName().Version.ToString();
            client.Headers["User-Agent"] = $"{name}/{version} (+https://github.com/LambentLight/LambentLight)";
            // Subscribe the event that changes the progress bar value
            client.DownloadProgressChanged += Client_DownloadProgressChanged;
            client.DownloadStringCompleted += Client_DownloadStringCompleted;
            client.DownloadFileCompleted += Client_DownloadFileCompleted;
            // Finally, return the new WebClient
            return client;
        }

        #endregion

        #region Public Functions

        /// <summary>
        /// Downloads a file.
        /// </summary>
        /// <param name="from">The URL of the file.</param>
        /// <param name="to">The location where the file should be downloaded.</param>
        /// <returns>true if the operation succeeded, false otherwise.</returns>
        public static async Task<bool> DownloadFileAsync(string from, string to)
        {
            try
            {
                // Create a new web client
                using (WebClient client = CreateWebClient())
                {
                    // Try to download the file
                    await client.DownloadFileTaskAsync(from, to);
                    // And show that the operation was successful
                    return true;
                }
            }
            catch (WebException e)
            {
                // If we got a HTTP exception, log it and return
                Logger.Error("Error while downloading '{0}': {1}", from, e.Message);
                return false;
            }
        }
        /// <summary>
        /// Downloads the content of a URL as a string.
        /// </summary>
        /// <param name="from">The URL to fetch.</param>
        /// <returns>The contents of the response if the request succeeded, null otherwise.</returns>
        public static async Task<string> DownloadStringAsync(string from)
        {
            try
            {
                // Create a new web client
                using (WebClient client = CreateWebClient())
                {
                    // Try to download the string and return it
                    return await client.DownloadStringTaskAsync(from);
                }
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
        public static async Task<T> DownloadJSONAsync<T>(string from, params JsonConverter[] converters)
        {
            // Request the string as usual
            string contents = await DownloadStringAsync(from);

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
        /// Event that gets triggered when the download progress changes.
        /// </summary>
        private static void Client_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            // Get the bytes received and the total number
            float total = e.TotalBytesToReceive;
            float current = e.BytesReceived;

            // Calculate the percentage of the download
            int percentage = (int)(current / total * 100f);

            // If the percetage is not under 0 or over 100
            if (percentage >= Program.Form.GeneralProgressBar.Minimum &&
                percentage <= Program.Form.GeneralProgressBar.Maximum)
            {
                // Set it on the progress bar
                Program.Form.Invoke(new Action(() => Program.Form.GeneralProgressBar.Value = percentage));
            }
        }

        /// <summary>
        /// Event triggered when a file download is completed.
        /// </summary>
        private static void Client_DownloadFileCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
        {
            // Reset the ProgressBar Value
            Program.Form.Invoke(new Action(() => Program.Form.GeneralProgressBar.Value = 0));
        }

        /// <summary>
        /// Event triggered when a string download is completed.
        /// </summary>
        private static void Client_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            // Reset the ProgressBar Value
            Program.Form.Invoke(new Action(() => Program.Form.GeneralProgressBar.Value = 0));
        }

        #endregion
    }
}
