using System.Data.Common;

namespace DataAccess.Interfaces
{
    public interface IConfigurationFactory
    {
        DbConnection GetConnection();
    }
}