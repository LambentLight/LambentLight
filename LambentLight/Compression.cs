using NLog;
using SharpCompress.Archives;
using SharpCompress.Common;
using SharpCompress.Readers;
using System.IO;
using System.Threading.Tasks;

namespace LambentLight
{
    /// <summary>
    /// Class that deals with the extraction of compressed files.
    /// </summary>
    public static class Compression
    {
        /// <summary>
        /// The logger for our current class.
        /// </summary>
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();
        /// <summary>
        /// The extraction options for SharpCompress.
        /// </summary>
        private static readonly ExtractionOptions ExtractOpts = new ExtractionOptions() { ExtractFullPath = true };
        
        /// <summary>
        /// Extracts the compressed file to the specified folder.
        /// </summary>
        /// <param name="file">The file to extract.</param>
        /// <param name="output">Where the files should be extracted.</param>
        public static async Task Extract(string file, string output)
        {
            // Wait just to shut the fucking compiler
            await Task.Delay(0);

            // Open the file as a streamer and feed it into the Compression reader
            using (Stream stream = File.OpenRead(file))
            using (IArchive archive = ArchiveFactory.Open(stream))
            {
                // Get the entries from the archive
                IReader reader = archive.ExtractAllEntries();

                // While there are entries available
                while (reader.MoveToNextEntry())
                {
                    // If the entry is not a directory
                    if (!reader.Entry.IsDirectory)
                    {
                        // If we are on a debug build
                        #if DEBUG
                            Logger.Debug("Currently extracting: {0}", reader.Entry.Key);
                        #endif

                        // Write it to our output directory
                        reader.WriteEntryToDirectory(output, ExtractOpts);
                    }
                }
            }
        }
    }
}
