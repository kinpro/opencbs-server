using System.Data;

namespace OPENCBS.Server
{
	public interface IConnectionProvider
	{
		IDbConnection GetConnection();
	}
}
