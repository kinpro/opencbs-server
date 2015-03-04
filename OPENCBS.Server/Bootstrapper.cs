using StructureMap;
using Nancy.Bootstrapper;
using Nancy.Bootstrappers.StructureMap;
using Nancy.Json;

namespace OPENCBS.Server
{
	public class Bootstrapper : StructureMapNancyBootstrapper
	{
        protected override void ApplicationStartup(IContainer container, IPipelines pipelines)
        {
            base.ApplicationStartup(container, pipelines);
            JsonSettings.RetainCasing = true;
        }

		protected override void ConfigureApplicationContainer(IContainer existingContainer)
		{
            existingContainer.Configure(x => x.AddRegistry<MSSQLRegistry>());
		}
	}
}
