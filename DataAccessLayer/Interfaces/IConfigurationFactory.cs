using System.Data.Common;

namespace DataAccessLayer.Interfaces
{
    public interface IConfigurationFactory
    {
        DbConnection GetConnection();
    }
}