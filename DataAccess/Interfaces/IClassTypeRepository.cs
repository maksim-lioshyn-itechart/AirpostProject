using DataAccess.Models;
using System.Threading.Tasks;

namespace DataAccess.Interfaces
{
    public interface IClassTypeRepository : IBaseRepository<ClassTypeEntity>
    {
        Task<ClassTypeEntity> GetBy(string name);
    }
}