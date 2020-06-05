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
        [Option("websocket-ip", Default = "127.0.0.1", HelpText = "WebSocket: IP Address to bind.")]
        public string WebSocketIP { get; set; }
        /// <summary>
        /// The port that the WebSocket will be binded to.
        /// </summary>
        [Option("websocket-port", Default = 7013, HelpText = "WebSocket: Port to bind.")]
        public int WebSocketPort { get; set; }
        /// <summary>
        /// If SSL should be used for the WebSocket.
        /// </summary>
        [Option("websocket-ssl", Default = false, HelpText = "WebSocket: If SSL should be used or not.")]
        public bool WebSocketSSL { get; set; }
        /// <summary>
        /// The working directory of the program.
        /// </summary>
        [Option('d', "directory", Default = directory, HelpText = "The directory used to store Builds and Data Folders.")]
        public string Directory { get; set; }
        /// <summary>
        /// The working directory of the program.
        /// </summary>
        [Option('l', "log-file", Default = log, HelpText = "The file used to store a log file.")]
        public string LogFile { get; set; }
        /// <summary>
        /// The IPs that are authorized to make WebSocket requests.
        /// </summary>
        [Option('a', "authorized", Required = false, HelpText = "IPs that are allowed to connect.")]
        public IEnumerable<string> Allowed { get; set; } = new List<string> { "127.0.0.1" };
    }
}
