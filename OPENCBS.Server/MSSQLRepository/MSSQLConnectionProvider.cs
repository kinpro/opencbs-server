using System.Data;
using System.Data.SqlClient;

namespace OPENCBS.Server
{
	public class MSSQLConnectionProvider : IConnectionProvider
	{
		public IDbConnection GetConnection()
		{
			var csb = new SqlConnectionStringBuilder();
			csb.DataSource = @"localhost\sqlexpress2012";
			csb.InitialCatalog = "vtn_2015_02_20";
			csb.UserID = "sa";
			csb.Password = "opencbs";
			var connection = new SqlConnection();
			connection.ConnectionString = csb.ConnectionString;
			connection.Open();
			return connection;
		}
	}
}
