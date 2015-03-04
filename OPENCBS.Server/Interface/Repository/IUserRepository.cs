using System.Collections.Generic;

namespace OPENCBS.Server
{
	public interface IUserRepository
	{
		List<User> GetAll();
        User Get(string username, string password);
	}
}
