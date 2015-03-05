using StructureMap.Configuration.DSL;

namespace OPENCBS.Server
{
    public class BaseRegistry : Registry
    {
        public BaseRegistry()
        {
            Scan(scanner =>
            {
                scanner.WithDefaultConventions();
                scanner.Assembly("OPENCBS.Server");
            });
            For<ISessionProvider>().Singleton().Use<SessionProvider>();
        }
    }
}
