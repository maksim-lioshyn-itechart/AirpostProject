using DataAccessLayer.Interfaces;
using System.Data.Common;
using System.Data.SqlClient;

namespace DataAccessLayer.Tests
{
    public class Test : IConfigurationFactory
    {
        public DbConnection GetConnection()
        {
            var connectionString = "Data Source=localhost;Initial Catalog=Airport;Integrated Security=True";
            return new SqlConnection(connectionString);
        }
    }
}
