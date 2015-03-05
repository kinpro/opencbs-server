using Nancy;
using Nancy.Security;

namespace OPENCBS.Server
{
    public class UserModule : NancyModule
    {
        public UserModule (IUserRepository userRepository) : base("/api/users")
        {
            this.RequiresAuthentication();
            Get["/"] = x =>
            {
                this.RequiresClaims(new[] { "UserList" });
                return userRepository.GetAll();
            };
        }
    }
}
