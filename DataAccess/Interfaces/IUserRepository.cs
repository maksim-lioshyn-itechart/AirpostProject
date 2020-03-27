using DataAccess.Models;
using System.Threading.Tasks;

namespace DataAccess.Interfaces
{
    public interface IUserRepository : IBaseRepository<UserEntity>
    {
        Task<UserEntity> GetBy(string email, string phone);
    }
}