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
            // Open the file as a streamer and feed it into the Compression reader
            using (Stream FileStream = File.OpenRead(file))
            using (IReader Reader = ReaderFactory.Open(FileStream))
            {
                // While there are entries available
                while (Reader.MoveToNextEntry())
                {
                    // If the entry is not a directory
                    if (!Reader.Entry.IsDirectory)
                    {
                        // Write it to our output directory
                        Reader.WriteEntryToDirectory(output, ExtractOpts);
                    }
                }
            }
        }
    }
}
