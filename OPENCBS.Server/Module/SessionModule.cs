using System;
using System.Security.Authentication;
using Nancy;
using Nancy.ModelBinding;

namespace OPENCBS.Server
{
    public class SessionModule : NancyModule
    {
        public SessionModule(IUserRepository userRepository, ISessionProvider sessionProvider) : base("/api/sessions")
        {
            Post["/"] = x =>
            {
                var user = this.Bind<User>();
                if (string.IsNullOrEmpty(user.UserName) || string.IsNullOrEmpty(user.Password))
                {
                    throw new InvalidCredentialException();
                }

                user = userRepository.Get(user.UserName, user.Password);
                if (user == null)
                {
                    throw new InvalidCredentialException();
                }

                var session = new Session { Id = Guid.NewGuid(), User = user };
                sessionProvider.Add(session);

                return new
                {
                    Id = session.Id,
                    UserId = session.User.Id
                };
            };
        }
    }
}
