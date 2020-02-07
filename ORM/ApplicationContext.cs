using Microsoft.Extensions.Configuration;
using System.Data.Common;
using System.Data.SqlClient;
using System.IO;

namespace ORM
{
    public class ApplicationContext
    {
        public DbConnection OpenConnection()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            var configuration = builder.Build();

            return new SqlConnection(configuration.GetConnectionString("DefaultConnection"));
        }
    }
}
