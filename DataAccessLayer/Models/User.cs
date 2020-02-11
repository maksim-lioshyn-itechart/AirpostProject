using System;

namespace DataAccessLayer.Models
{
    public class User: BasicModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public Guid? RoleId { get; set; }
    }
}
