using Microsoft.Data.SqlClient;

namespace AdoNet.Model.Interfaces
{
    public interface IDbConnectionFactory
    {
        SqlConnection CreateConnection();
    }
}
