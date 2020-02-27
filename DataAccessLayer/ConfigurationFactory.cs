using DataAccessLayer.Interfaces;
using System.Data.Common;
using System.Data.SqlClient;

namespace DataAccessLayer
{
    public class ConfigurationFactory : IConfigurationFactory
    {
        private readonly string _connectionString;

        public ConfigurationFactory()
        {

        }
        public ConfigurationFactory(string connectionString)
        {
            _connectionString = connectionString;
        }

        public DbConnection GetConnection() => new SqlConnection(_connectionString);
    }
}
