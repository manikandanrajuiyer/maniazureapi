using System.Data;

namespace Mani.Azure.Api.Data.Interfaces.DataAccess
{
    public interface ISqlConnectionProvider
    {
        Task<IDbConnection> GetConnection();
    }
}
