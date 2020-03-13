using DataAccess.Models;
using System;
using System.Threading.Tasks;
using DataAccess.Interfaces;

namespace DataAccess.Interfaces
{
    public interface IUserPasswordRepository : IBaseRepository<UserPasswordEntity>
    {
        Task<UserPasswordEntity> GetBy(Guid userId);
    }
}