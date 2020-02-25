using System;
using System.Threading.Tasks;
using BusinessLogicLayer.Models;

namespace BusinessLogicLayer.Interfaces
{
    public interface IUserService: IService<UserBm>
    {
        Task<bool> ValidatePassword(Guid userId, string password);
    }
}