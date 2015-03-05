using System;
using System.Linq;
using StructureMap;
using Nancy;
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

        protected override void RequestStartup(IContainer container, IPipelines pipelines, NancyContext context)
        {
            pipelines.BeforeRequest.AddItemToStartOfPipeline(GetAuthenticationHook(container));
            pipelines.OnError.AddItemToEndOfPipeline((ctx, err) => ErrorResponse.FromException(err));
            base.RequestStartup(container, pipelines, context);
        }

        static Func<NancyContext, Response> GetAuthenticationHook(IContainer container)
        {
            return context =>
            {
                var idText = context.Request.Headers["X-Session-ID"].FirstOrDefault();
                if (string.IsNullOrEmpty(idText))
                {
                    return null;
                }

                Guid id;
                if (!Guid.TryParse(idText, out id))
                {
                    return null;
                }

                var sessionProvider = container.GetInstance<ISessionProvider>();
                var session = sessionProvider.Get(id);
                if (session == null)
                {
                    return null;
                }

                context.CurrentUser = session.User;
                return null;
            };
        }
    }
}
