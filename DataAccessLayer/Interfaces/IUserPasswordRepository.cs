using System;
using System.Threading.Tasks;
using DataAccessLayer.Models;

namespace DataAccessLayer.Interfaces
{
    public interface IUserPasswordRepository: IBaseRepository<UserPassword>
    {
        Task<UserPassword> GetByUserId(Guid userId);
    }
}