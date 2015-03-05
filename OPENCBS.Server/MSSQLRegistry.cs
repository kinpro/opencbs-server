namespace OPENCBS.Server
{
	public class MSSQLRegistry : BaseRegistry
	{
        public MSSQLRegistry()
		{
			For<IConnectionProvider>().Use<MSSQLConnectionProvider>();
			For<IUserRepository>().Use<MSSQLUserRepository>();
		}
	}
}
