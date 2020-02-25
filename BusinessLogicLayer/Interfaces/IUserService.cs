using BusinessLogicLayer.Models;
using System;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Interfaces
{
    public interface IUserService : IService<UserBm>
    {
        Task<bool> ValidatePassword(Guid userId, string password);
        Task<bool> UpdatePassword(Guid userId, string oldPassword, string newPassword);
    }
}