using Mani.Azure.Api.Data.Interfaces.DataAccess;
using Mani.Azure.Api.Models;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Options;
using System.Data;

namespace Jerry.Data.DataAccess
{
    public class EmployeeDBConnection : ISqlConnectionProvider
    {
        private readonly string connectionString;

        private SqlConnection? _connection;

        public EmployeeDBConnection(IOptions<AppConfig> _config)
        {
            connectionString = _config.Value.ConnectionString;
        }

        public async Task<IDbConnection> GetConnection()
        {
            if (_connection == null)
            {
                _connection = new SqlConnection(connectionString);

                if(_connection.State != ConnectionState.Open)
                    await _connection.OpenAsync();
            }

            return _connection;
        }
    }
}
