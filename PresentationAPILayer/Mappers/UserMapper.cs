using BusinessLogicLayer.Models;
using PresentationAPILayer.Models;

namespace PresentationAPILayer.Mappers
{
    public static class UserMapper
    {
        public static UserBm ToBm(this UserVm user)
        {
            return new UserBm
            {
                Id = user.Id,
                Email = user.Email,
                Address = user.Address,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Phone = user.Phone,
                RoleId = user.RoleId,
                Password = user.Password
            };
        }

        public static UserVm ToVm(this UserBm user)
        {
            return new UserVm
            {
                Id = user.Id,
                Email = user.Email,
                Address = user.Address,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Phone = user.Phone,
                RoleId = user.RoleId,
                Password = user.Password
            };
        }
    }
}
