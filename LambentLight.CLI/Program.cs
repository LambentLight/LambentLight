using CommandLine;
using System.Threading;
using WatsonWebsocket;

namespace LambentLight.CLI
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            // Parse the command line arguments and launch the program
            Parser.Default.ParseArguments<Arguments>(args).WithParsed(x => Run(x));
        }

        public static void Run(Arguments args)
        {
            // If we need to start in daemon mode, run the websocket server
            if (args.Daemon)
            {
                WatsonWsServer server = new WatsonWsServer(args.Address, args.Port, args.SSL);
                server.Start();
                Thread.Sleep(Timeout.Infinite);
            }
        }
    }
}
