using System.Collections.Generic;
using System.Threading.Tasks;
using DataAccess.Interfaces;
using DataAccess.Models;

namespace DataAccess.Interfaces
{
    public interface IClassTypeRepository : IBaseRepository<ClassTypeEntity>
    {
        Task<ClassTypeEntity> GetBy(string name);
    }
}