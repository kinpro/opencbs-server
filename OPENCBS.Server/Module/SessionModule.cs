using Nancy;
using Nancy.ModelBinding;

namespace OPENCBS.Server
{
    public class SessionModule : NancyModule
    {
        public SessionModule() : base("/api/sessions")
        {
            Post["/"] = x =>
            {
                var user = this.Bind<User>();
                return user;
            };
        }
    }
}
