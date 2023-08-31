using AdoNet.Model.DbConnection.Interfaces;
using Microsoft.Data.SqlClient;

namespace AdoNet.Model.DbConnection
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
            // Берем строку подключения из конфигурации
            var connectionStr = _configuration.GetConnectionString("LocalSqlServer");

            var connection = new SqlConnection(connectionStr); // Создаем объект подключения

            connection.Open(); // Окрываем подключение к БД

            return connection;
        }
    }
}
