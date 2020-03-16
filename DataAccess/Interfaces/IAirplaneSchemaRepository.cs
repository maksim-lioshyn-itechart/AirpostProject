using DataAccess.Models;
using System.Threading.Tasks;

namespace DataAccess.Interfaces
{
    public interface IAirplaneSchemaRepository : IBaseRepository<AirplaneSchemaEntity>
    {
        Task<AirplaneSchemaEntity> GetBy(string name);
    }
}