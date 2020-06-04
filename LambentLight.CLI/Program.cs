using CommandLine;
using Serilog;
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
            // Configure the Serilog Logging
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.Console()
                .CreateLogger();

            // If we need to start in daemon mode, run the websocket server
            if (args.Daemon)
            {
                Log.Information("Starting LambentLight in Daemon Mode on {0}:{1}", args.Address, args.Port);
                WatsonWsServer server = new WatsonWsServer(args.Address, args.Port, args.SSL);
                server.Start();
                Thread.Sleep(Timeout.Infinite);
            }
        }
    }
}
