using CommandLine;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Serilog;
using System;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using WatsonWebsocket;

namespace LambentLight.Daemon
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

            // Print the a message with information about the current system
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                Log.Information($"Starting LambentLight Daemon in Windows");
            }
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                Log.Information($"Starting LambentLight Daemon in Linux");
            }
            // If we are on something not supported, return
            else
            {
                Log.Fatal("Unsuported operating system detected!");
                Log.Fatal("LambentLight can only be used on Windows and Linux");
                Environment.Exit(1);
            }

            // And run the websocket server
            WatsonWsServer server = new WatsonWsServer(args.IP, args.Port, args.SSL);
            server.MessageReceived += Server_MessageReceived;
            server.ClientConnected += Server_ClientConnected;
            server.ClientDisconnected += Server_ClientDisconnected;
            server.ServerStopped += Server_ServerStopped;
            Log.Information("Starting LambentLight in Daemon Mode on {0}:{1}", args.IP, args.Port);
            server.Start();
            Thread.Sleep(Timeout.Infinite);
        }

        private static void Server_MessageReceived(object sender, MessageReceivedEventArgs e)
        {
            // Convert the data to a string
            string json = Encoding.UTF8.GetString(e.Data);
            // Convert it to JSON
            JObject info = JsonConvert.DeserializeObject<JObject>(json);

            // And check for the information requested by the server
            switch (info["data"].ToString())
            {
            }
        }

        private static void Server_ClientConnected(object sender, ClientConnectedEventArgs e)
        {
            Log.Information("Client {0} connected", e.IpPort);
        }

        private static void Server_ClientDisconnected(object sender, ClientDisconnectedEventArgs e)
        {
            Log.Information("Client {0} disconnected", e.IpPort);
        }

        private static void Server_ServerStopped(object sender, EventArgs e)
        {
            Log.Information("Websocket Server has been stopped");
        }
    }
}
