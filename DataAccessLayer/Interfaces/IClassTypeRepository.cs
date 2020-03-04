using System.Collections.Generic;
using System.Threading.Tasks;
using DataAccessLayer.Models;

namespace DataAccessLayer.Interfaces
{
    public interface IClassTypeRepository : IBaseRepository<ClassTypeEntity>
    {
        Task<ClassTypeEntity> GetBy(string name);
    }
}