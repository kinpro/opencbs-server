using StructureMap.Configuration.DSL;

namespace OPENCBS.Server
{
	public class MSSQLRegistry : Registry
	{
		public MSSQLRegistry()
		{
			Scan(scanner => scanner.WithDefaultConventions());

			For<IConnectionProvider>().Use<MSSQLConnectionProvider>();
			For<IUserRepository>().Use<MSSQLUserRepository>();
		}
	}
}
