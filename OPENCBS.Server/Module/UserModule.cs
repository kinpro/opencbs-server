using Nancy;

namespace OPENCBS.Server
{
	public class UserModule : NancyModule
	{
		public UserModule (IUserRepository userRepository) : base("/api/users")
		{
			Get["/"] = x => userRepository.GetAll();
		}
	}
}
