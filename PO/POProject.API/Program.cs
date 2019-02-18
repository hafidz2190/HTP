using log4net;
using Microsoft.Practices.Unity;
using Nancy;
using Nancy.Hosting.Self;
using POProject.API.SignalR.Builder;
using POProject.API.SignalR.Utilities;
using POProject.Builder;
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

            IUnityContainer container = new UnityContainer();
            IDictionary<string, object> mainOjectMap;

            MainObjectBuilder mainObjectBuilder = new MainObjectBuilder(container);
            mainOjectMap = mainObjectBuilder.BuildMainObject();

            AutoMapBuilder autoMapBuilder = new AutoMapBuilder();
            autoMapBuilder.BuildAutoMap();

            HostConfiguration config = new HostConfiguration
            {
                UrlReservations = { CreateAutomatically = true }
            };

            log.Info("Open Connection to Server");
            Uri uri = new Uri("http://localhost:2202");
            NancyHost host;

            try
            {
                host = new NancyHost(new CustomNancyBootstrapper(container), config, uri);
            }
            catch(Exception e)
            {
                throw e;
            }

            var signalRHostBaseAddress = "http://+:8885";
            SignalRHost<Startup> signalRHost = SignalRHostBuilder<Startup>.BuildSignalRHost(signalRHostBaseAddress);

            try
            {
                log.Info("Starting Server Host");
                host.Start();
                Console.WriteLine($"Server is up : {uri.AbsoluteUri}");

                signalRHost.Open();
                Console.WriteLine(string.Format("Host Connection opened at: {0}", signalRHostBaseAddress));

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
