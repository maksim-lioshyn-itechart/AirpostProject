using System.Data.Common;
using System.Data.SqlClient;
using DataAccessLayer.Interfaces;

namespace DataAccessLayer.Tests
{
    public class ConnectionFactory: IConfigurationFactory
    {
        static string connectionString =
            "Data Source=localhost;Initial Catalog=Airport;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
       
        public DbConnection GetConnection()
        {
            var connection = new SqlConnection(connectionString);
            connection.Open();

            return connection;
        }
    }
}
