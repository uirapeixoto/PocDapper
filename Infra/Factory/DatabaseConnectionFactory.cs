using Infra.Interface;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Diagnostics.CodeAnalysis;

namespace Infra.Factory
{
    [ExcludeFromCodeCoverage]
    public class DatabaseConnectionFactory : IDatabaseConnectionFactory
    {
        private IConfiguration _config;

        public DatabaseConnectionFactory(IConfiguration config)
        {
            _config = config;
        }

        public IDbConnection GetConnection() => new SqlConnection(_config.GetConnectionString("CustomerDB"));
    }
}
