using CommandLine;
using System.Collections.Generic;

namespace LambentLight.CLI
{
    /// <summary>
    /// Arguments sent via the command line.
    /// </summary>
    public class Arguments
    {
        [Option('d', "daemon", Default = false, HelpText = "Starts LambentLight in Daemon mode.")]
        public bool Daemon { get; set; }

        [Option('b', "bind", Default = "127.0.0.1", HelpText = "Address to bind in Daemon mode.")]
        public string Address { get; set; }
        [Option('p', "port", Default = 7013, HelpText = "Port to bind in Daemon mode.")]
        public int Port { get; set; }
        [Option('s', "ssl", Default = false, HelpText = "If Daemon mode should use SSL or not.")]
        public bool SSL { get; set; }
        [Option('a', "authorized", Required = false, HelpText = "The IPs that are allowed to connect to this server")]
        public IEnumerable<string> Allowed { get; set; } = new List<string> { "127.0.0.1" };
    }
}
