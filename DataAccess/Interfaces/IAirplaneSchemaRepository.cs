using System.Collections.Generic;
using System.Threading.Tasks;
using DataAccess.Interfaces;
using DataAccess.Models;

namespace DataAccess.Interfaces
{
    public interface IAirplaneSchemaRepository : IBaseRepository<AirplaneSchemaEntity>
    {
        Task<AirplaneSchemaEntity> GetBy(string name);
    }
}