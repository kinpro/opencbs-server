using System.Collections.Generic;
using System.Linq;
using Dapper;

namespace OPENCBS.Server
{
	public class MSSQLUserRepository : IUserRepository
	{
		readonly IConnectionProvider _connectionProvider;

		public MSSQLUserRepository(IConnectionProvider connectionProvider)
		{
			_connectionProvider = connectionProvider;
		}

		public List<User> GetAll()
		{
			const string query = @"
				select
					id Id,
					user_name UserName,
					first_name FirstName,
					last_name LastName
				from
			        dbo.Users
			";
			using (var connection = _connectionProvider.GetConnection())
			{
                return connection.Query<User>(query).ToList();
			}
		}

        public User Get(string username, string password)
        {
            const string query = @"
                select
                    id Id,
                    user_name UserName,
                    first_name FirstName,
                    last_name LastName
                from
                    dbo.Users
                where
                    user_name = @username
                    and user_pass = @password
            ";
            using (var connection = _connectionProvider.GetConnection())
            {
                return connection.Query<User>(query, new { username, password }).FirstOrDefault();
            }
        }
	}
}
