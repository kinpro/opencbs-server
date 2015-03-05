using System;
using System.Threading;
using Nancy.Hosting.Self;

namespace OPENCBS.Server.SelfHost
{
    class MainClass
    {
        public static void Main()
        {
            var exitEvent = new ManualResetEvent(false);

            Console.CancelKeyPress += (sender, args) =>
            {
                    args.Cancel = true;
                    exitEvent.Set();
            };
            Console.WriteLine("OPENCBS server is running...");
            Console.WriteLine("Press CTRL+C to stop");

            var config = new HostConfiguration();
            config.UrlReservations.CreateAutomatically = true;
            using (var host = new NancyHost(config, new Uri("http://localhost:12345")))
            {
                host.Start();
                exitEvent.WaitOne();
            }
        }
    }
}
