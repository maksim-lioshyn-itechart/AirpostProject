using System;
using System.Collections.Generic;
using System.Text;

namespace ORM.Models
{
    public class ContactInformation: BasicModel
    {
        public Guid ApplicationUserId { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
    }
}
