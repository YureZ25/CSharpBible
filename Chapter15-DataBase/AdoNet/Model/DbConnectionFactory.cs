using AdoNet.Model.Interfaces;
using Microsoft.Data.SqlClient;

namespace AdoNet.Model
{
    public class DbConnectionFactory : IDbConnectionFactory
    {
        private readonly IConfiguration _configuration;

        public DbConnectionFactory(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public SqlConnection CreateConnection()
        {
            var connectionStr = _configuration.GetConnectionString("LocalSqlServer");

            var connection = new SqlConnection(connectionStr);

            connection.Open();

            return connection;
        }
    }
}
