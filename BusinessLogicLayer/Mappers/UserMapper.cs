using BusinessLogicLayer.Models;
using DataAccessLayer.Models;

namespace BusinessLogicLayer.Mappers
{
    public static class UserMapper
    {
        public static User ToDal(this UserBm user)
        {
            return new User
            {
                Id = user.Id,
                Email = user.Email,
                Address = user.Address,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Phone = user.Phone,
                RoleId = user.RoleId
            };
        }

        public static UserBm ToBm(this User user)
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
                Password = string.Empty
            };
        }
    }
}
