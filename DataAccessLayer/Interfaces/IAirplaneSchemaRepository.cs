using System.Collections.Generic;
using System.Threading.Tasks;
using DataAccessLayer.Models;

namespace DataAccessLayer.Interfaces
{
    public interface IAirplaneSchemaRepository : IBaseRepository<AirplaneSchemaEntity>
    {
        Task<AirplaneSchemaEntity> GetBy(string name);
    }
}