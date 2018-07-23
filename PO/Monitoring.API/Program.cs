using log4net;
using Nancy.Hosting.Self;
using System;
using System.Runtime.InteropServices;
using System.Xml;

namespace Monitoring.API
{
    public class Program
    {
        [DllImport("kernel32.dll")]
        static extern IntPtr GetConsoleWindow();


        [DllImport("user32.dll")]
        static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        const int SW_HIDE = 0;
        const int SW_SHOW = 5;

        private static readonly ILog log = LogManager.GetLogger(typeof(Program));
        static void Main()
        {
            var handle = GetConsoleWindow();

            //hide window
            //ShowWindow(handle, SW_HIDE);

            HostConfiguration config = new HostConfiguration
            {
                UrlReservations = { CreateAutomatically = true }
            };

            string port = "2502";
            System.IO.FileInfo info = new System.IO.FileInfo("setDB.xml");
            if (info.Exists)
            {
                XmlDataDocument xmldoc = new XmlDataDocument();
                XmlNodeList xmlnode;
                System.IO.FileStream fs = new System.IO.FileStream("product.xml", System.IO.FileMode.Open, System.IO.FileAccess.Read);
                xmldoc.Load(fs);
                xmlnode = xmldoc.GetElementsByTagName("port");
                port = xmlnode[0].InnerText;
            }

            Uri uri = new Uri($"http://localhost:{port}");

            using (var host = new NancyHost(config, uri))
            {
                log.Info("Entering Application");
                host.Start();
                log.Info("Open Connection to Server");
                Console.WriteLine("Application is up @localhost:2502");
                Console.ReadLine();
            }
        }
    }
}
