using ORM.Models;

namespace DataAccessLayer.Interfaces
{
    public interface IUserRepository: IBaseOperationRepository<User>
    {
        User GetByName(string name);
    }
}