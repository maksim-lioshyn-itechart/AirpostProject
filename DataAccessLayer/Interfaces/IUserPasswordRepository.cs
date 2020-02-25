using DataAccessLayer.Models;
using System;
using System.Threading.Tasks;

namespace DataAccessLayer.Interfaces
{
    public interface IUserPasswordRepository : IBaseRepository<UserPassword>
    {
        Task<UserPassword> GetByUserId(Guid userId);
    }
}