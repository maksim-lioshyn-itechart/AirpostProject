using ORM.Models;

namespace DataAccessLayer.Interfaces
{
    public interface IUserRepository: IBaseRepository<User>
    {
        User GetByName(string name);
    }
}