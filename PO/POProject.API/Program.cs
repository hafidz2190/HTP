using log4net;
using Nancy;
using Nancy.Hosting.Self;
using POProject.API.SignalR.Builder;
using POProject.API.SignalR.Utilities;
using System;
using System.Collections.Generic;
using System.Threading;

namespace POProject.API
{
    public class Program : NancyModule
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(Program));
        static void Main()
        {
            log.Info("Entering Application");
            HostConfiguration config = new HostConfiguration
            {
                UrlReservations = { CreateAutomatically = true }
            };

            log.Info("Open Connection to Server");
            Uri uri = new Uri("http://localhost:2202");
            var host = new NancyHost(config, uri);

            var signalRHostBaseAddress = "http://+:8885";
            SignalRHost<Startup> signalRHost = SignalRHostBuilder<Startup>.BuildSignalRHost(signalRHostBaseAddress);

            try
            {
                log.Info("Starting Server Host");
                host.Start();
                Console.WriteLine($"Server is up : {uri.AbsoluteUri}");

                signalRHost.Open();
                Console.WriteLine(string.Format("SignalR Host opened: {0}", signalRHostBaseAddress));

                // example how to broadcast message to specific connection id
                //var context = GlobalHost.ConnectionManager.GetHubContext<MonitorHub>();
                //context.Clients.Client("connection id").addMessage("message");

                // read active connections every 5 seconds
                Thread readConnectionThread = new Thread(ReadConnections);
                readConnectionThread.Start();

                Console.ReadLine();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }
            finally
            {
                host.Stop();
                signalRHost.Close();
                Console.WriteLine(string.Format("SignalR Host closed: {0}", signalRHostBaseAddress));
            }
        }

        static void ReadConnections()
        {
            while (true)
            {
                Thread.Sleep(5000);

                var connectionMap = ConnectionMap.GetConnectionMap();

                Console.WriteLine("Connection Created: " + ConnectionMap.Count);

                foreach (KeyValuePair<string, ClientConnectionModel> e in connectionMap)
                {
                    Console.WriteLine(string.Format("{0} => {1} => [{2}]", e.Key, e.Value.IsRequesting, string.Join(", ", e.Value.ConnectionIds)));
                }
            }
        }
    }
}
