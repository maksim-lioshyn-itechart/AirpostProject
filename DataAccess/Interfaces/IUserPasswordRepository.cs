using DataAccess.Models;
using System;
using System.Threading.Tasks;

namespace DataAccess.Interfaces
{
    public interface IUserPasswordRepository : IBaseRepository<UserPasswordEntity>
    {
        Task<UserPasswordEntity> GetBy(Guid userId);
    }
}