using CommandLine;
using System.Collections.Generic;

namespace LambentLight.Daemon
{
    /// <summary>
    /// Arguments sent via the command line.
    /// </summary>
    public class Arguments
    {
        /// <summary>
        /// The OS-aware default directory.
        /// </summary>
        private const string directory =
#if WINDOWS
            "C:\\ProgramData\\LambentLight";
#else
            "/var/lib/lambentlight";
#endif

        [Option('i', "ip", Default = "127.0.0.1", HelpText = "IP Address to bind.")]
        public string IP { get; set; }
        [Option('p', "port", Default = 7013, HelpText = "Port to bind.")]
        public int Port { get; set; }
        [Option('d', "dir", Default = directory, HelpText = "The directory used to store Builds and Data Folders.")]
        public string Directory { get; set; }
        [Option('s', "ssl", Default = false, HelpText = "If SSL should be used or not.")]
        public bool SSL { get; set; }
        [Option('a', "authorized", Required = false, HelpText = "IPs that are allowed to connect.")]
        public IEnumerable<string> Allowed { get; set; } = new List<string> { "127.0.0.1" };
    }
}
