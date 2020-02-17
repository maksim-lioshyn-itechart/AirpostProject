using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.Models
{
    public class UserPassword: BasicModel
    {
        public Guid UserId { get; set; }
        public string Salt { get; set; }
        public string Hash { get; set; }
    }
}
