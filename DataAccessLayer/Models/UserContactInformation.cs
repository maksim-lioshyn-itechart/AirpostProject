using System;

namespace DataAccessLayer.Models
{
    public class UserContactInformation: BasicModel
    {
        public Guid UserId { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
    }
}
