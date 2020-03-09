using DataAccessLayer.Models;
using System;
using System.Threading.Tasks;

namespace DataAccessLayer.Interfaces
{
    public interface IUserPasswordRepository : IBaseRepository<UserPasswordEntity>
    {
        Task<UserPasswordEntity> GetBy(Guid userId);
    }
}