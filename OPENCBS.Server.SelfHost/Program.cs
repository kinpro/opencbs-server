using System;
using Nancy.Hosting.Self;

namespace OPENCBS.Server.SelfHost
{
	class MainClass
	{
		public static void Main()
		{
			var config = new HostConfiguration();
			config.UrlReservations.CreateAutomatically = true;
			using (var host = new NancyHost(config, new Uri("http://localhost:12345")))
			{
				host.Start();
				Console.ReadLine();
			}
		}
	}
}
