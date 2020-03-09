using API.Models;
using System;

namespace Test
{
    public static class StubsObjects
    {
        public static UserRoleViewModel UserRole = new UserRoleViewModel()
        {
            Id = Guid.NewGuid(),
            Name = Guid.NewGuid().ToString()
        };
    }
}
