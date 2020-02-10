using System.Threading.Tasks;
using ORM.Models;

namespace DataAccessLayer.Interfaces
{
    public interface IUserRepository: IBaseRepository<User>
    {
        User GetByName(string name);
        Task<User> GetByNameAsync(string name);
    }
}