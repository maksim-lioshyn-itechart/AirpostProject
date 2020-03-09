using BusinessLogic.Models;
using System;
using System.Threading.Tasks;

namespace BusinessLogic.Interfaces
{
    public interface IUserService : IService<User>
    {
        Task<bool> ValidatePassword(Guid userId, string password);
        Task<bool> UpdatePassword(Guid userId, string oldPassword, string newPassword);
    }
}