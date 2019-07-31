using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace LambentLight
{
    public static class Downloader
    {
        /// <summary>
        /// The logger for our current class.
        /// </summary>
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();
        /// <summary>
        /// The client to use for web requests.
        /// </summary>
        private static readonly WebClient Client = new WebClient();

        /// <summary>
        /// Prepares the client for the web requests.
        /// </summary>
        public static void Prepare()
        {
            // Set the event to refresh the progress bar
            Client.DownloadProgressChanged += OnDownloadProgressChanged;

            // Get the name and version of the current program
            string Name = System.Reflection.Assembly.GetExecutingAssembly().GetName().Name;
            string Version = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();
            Client.Headers["User-Agent"] = $"{Name}/{Version} (+https://github.com/LambentLight/LambentLight)";
        }

        /// <summary>
        /// Event that gets triggered when the download progress of a file changes.
        /// </summary>
        private static void OnDownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            // Calculate the percentage of the download
            int Percentage = (int)((float)e.BytesReceived / e.TotalBytesToReceive * 100f);

            // Make a sanity check to ensure that the percentage is on the correct location
            if (Percentage >= Program.Form.MainProgressBar.Minimum && Percentage <= Program.Form.MainProgressBar.Maximum)
            {
                // And set the value of the progress bar
                Program.Form.MainProgressBar.Value = Percentage;
            }
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
            Program.Form.MainProgressBar.Value = 0;
            // Return that we have succeeded
            return true;
        }

        /// <summary>
        /// Requests a URL as a string.
        /// </summary>
        /// <param name="from">The URL to fetch.</param>
        /// <returns>The contents of the response if the request succeeded, null otherwise.</returns>
        public static async Task<string> DownloadString(string from)
        {
            // Try to download the string
            try
            {
                // Use the asynchronous method
                string Output = await Client.DownloadStringTaskAsync(from);
                // Reset the progress bar
                Program.Form.MainProgressBar.Value = 0;
                // And return our string
                return Output;
            }
            // If we got a HTTP exception
            catch (WebException e)
            {
                Logger.Error("Error while fetching '{0}': {1}", from, e.Message);
                return null;
            }
        }
    }
}
