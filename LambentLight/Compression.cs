using SharpCompress.Archives;
using SharpCompress.Archives.Rar;
using SharpCompress.Archives.SevenZip;
using SharpCompress.Archives.Zip;
using SharpCompress.Common;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace LambentLight
{
    /// <summary>
    /// The type of compression used for the 
    /// </summary>
    public enum CompressionType
    {
        /// <summary>
        /// The classic ZIP file.
        /// </summary>
        Zip = 0,
        /// <summary>
        /// 7zip or Seven ZIP.
        /// </summary>
        SevenZip = 1,
        /// <summary>
        /// RAR from WinRAR.
        /// </summary>
        Rar = 2
    }

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
        /// <exception cref="InvalidOperationException">Thrown when the compression type is unsuported.</exception>
        public static async Task Extract(string file, string output, CompressionType type)
        {
            switch (type)
            {
                case CompressionType.Zip:
                    await ExtractZip(file, output);
                    break;
                case CompressionType.SevenZip:
                    await Extract7zip(file, output);
                    break;
                case CompressionType.Rar:
                    await ExtractRar(file, output);
                    break;
                default:
                    throw new InvalidOperationException($"{(int)type} is an invalid compression type for file {file}.");
            }
        }

        /// <summary>
        /// Extracts the ZIP file to the specified folder.
        /// </summary>
        /// <param name="file">The file to extract.</param>
        /// <param name="output">Where the files should be extracted.</param>
        public static async Task ExtractZip(string file, string output)
        {
            using (ZipArchive SevenZip = ZipArchive.Open(file))
            {
                foreach (ZipArchiveEntry Entry in SevenZip.Entries.Where(X => !X.IsDirectory))
                {
                    Entry.WriteToDirectory(output, ExtractOpts);
                }
            }
        }

        /// <summary>
        /// Extracts the 7zip file to the specified folder.
        /// </summary>
        /// <param name="file">The file to extract.</param>
        /// <param name="output">Where the files should be extracted.</param>
        public static async Task Extract7zip(string file, string output)
        {
            using (SevenZipArchive SevenZip = SevenZipArchive.Open(file))
            {
                foreach (SevenZipArchiveEntry Entry in SevenZip.Entries.Where(X => !X.IsDirectory))
                {
                    Entry.WriteToDirectory(output, ExtractOpts);
                }
            }
        }

        /// <summary>
        /// Extracts the 7zip file to the specified folder.
        /// </summary>
        /// <param name="file">The file to extract.</param>
        /// <param name="output">Where the files should be extracted.</param>
        public static async Task ExtractRar(string file, string output)
        {
            using (RarArchive Rar = RarArchive.Open(file))
            {
                foreach (RarArchiveEntry Entry in Rar.Entries.Where(X => !X.IsDirectory))
                {
                    Entry.WriteToDirectory(output, ExtractOpts);
                }
            }
        }
    }
}
