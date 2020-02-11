using System;
using System.Collections.Generic;
using System.Text;
using DataAccessLayer.Models;


namespace DataAccessLayer.Tests.Repositories
{
    public static class StabsEntities
    {
        public static User BaseUser = new User
        {
            Id = Guid.NewGuid(),
            FirstName = Guid.NewGuid().ToString(),
            LastName = Guid.NewGuid().ToString(),
            Login = Guid.NewGuid().ToString(),
            Password = Guid.NewGuid().ToString()
        };
    }
}
