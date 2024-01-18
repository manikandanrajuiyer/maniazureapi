using Dapper;
using Mani.Azure.Api.Data.Interfaces;
using Mani.Azure.Api.Data.Interfaces.DataAccess;
using System.Data;

namespace Mani.Azure.Api.Data.DataAccess
{
    public class SqlDapperDataAccess : ISqlDapperDataAccess
    {
        private readonly ISqlConnectionProvider _connectionProvider;


        public SqlDapperDataAccess(ISqlConnectionProvider connectionProvider)
        {
            _connectionProvider = connectionProvider;
        }

        private async Task<IDbConnection> GetConnection()
        {
            var conn = await _connectionProvider.GetConnection();

            return conn;
        }
        public async Task<IEnumerable<T>> ExecuteStoredProcedure<T>(string query, object parameters)
        {
            using IDbConnection conn = await GetConnection();
            return await conn.QueryAsync<T>(query, parameters, commandType: CommandType.StoredProcedure);
        }

    }
}
