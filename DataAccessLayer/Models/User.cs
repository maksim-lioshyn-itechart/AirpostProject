using System;

namespace DataAccessLayer.Models
{
    public class User: BasicModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public Guid RoleId { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
	}
}
