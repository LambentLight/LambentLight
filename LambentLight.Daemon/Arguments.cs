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
        /// <summary>
        /// The OS-aware log file.
        /// </summary>
        private const string log =
#if WINDOWS
            "C:\\ProgramData\\LambentLight\\LambentLight.log";
#else
            "/var/log/lambentlight/lambentlight.log";
#endif

        /// <summary>
        /// The IP that the WebSocket will be binded to.
        /// </summary>
        [Option('i', "ip", Default = "127.0.0.1", HelpText = "IP Address to bind.")]
        public string IP { get; set; }
        /// <summary>
        /// The port that the WebSocket will be binded to.
        /// </summary>
        [Option('p', "port", Default = 7013, HelpText = "Port to bind.")]
        public int Port { get; set; }
        /// <summary>
        /// The working directory of the program.
        /// </summary>
        [Option('d', "dir", Default = directory, HelpText = "The directory used to store Builds and Data Folders.")]
        public string Directory { get; set; }
        /// <summary>
        /// The working directory of the program.
        /// </summary>
        [Option('l', "log-file", Default = log, HelpText = "The file used to store a log file.")]
        public string LogFile { get; set; }
        /// <summary>
        /// If SSL should be used for the WebSocket.
        /// </summary>
        [Option('s', "ssl", Default = false, HelpText = "If SSL should be used or not.")]
        public bool SSL { get; set; }
        /// <summary>
        /// The IPs that are authorized to make WebSocket requests.
        /// </summary>
        [Option('a', "authorized", Required = false, HelpText = "IPs that are allowed to connect.")]
        public IEnumerable<string> Allowed { get; set; } = new List<string> { "127.0.0.1" };
    }
}
