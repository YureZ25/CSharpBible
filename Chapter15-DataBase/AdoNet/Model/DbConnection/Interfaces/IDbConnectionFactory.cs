using Microsoft.Data.SqlClient;

namespace AdoNet.Model.DbConnection.Interfaces
{
    public interface IDbConnectionFactory
    {
        SqlConnection CreateConnection();
    }
}
