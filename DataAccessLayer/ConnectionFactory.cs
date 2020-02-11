using System.Data.Common;
using System.Data.SqlClient;

namespace DataAccessLayer
{
    public class ConnectionFactory
    {
        static string connectionString =
            "Data Source=localhost;Initial Catalog=Airport;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
       
        public DbConnection GetOpenConnection()
        {
            var connection = new SqlConnection(connectionString);
            connection.Open();

            return connection;
        }
    }
}
