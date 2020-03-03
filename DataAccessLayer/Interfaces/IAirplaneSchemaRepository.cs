using System.Collections.Generic;
using System.Threading.Tasks;
using DataAccessLayer.Models;

namespace DataAccessLayer.Interfaces
{
    public interface IAirplaneSchemaRepository : IBaseRepository<AirplaneSchemaEntity>
    {
        Task<IEnumerable<AirplaneSchemaEntity>> GetBy(string name);
    }
}