using System.Security.Authentication;
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
                if (string.IsNullOrEmpty(user.UserName) || string.IsNullOrEmpty(user.Password))
                {
                    throw new InvalidCredentialException();
                }

                return user;
            };
        }
    }
}
