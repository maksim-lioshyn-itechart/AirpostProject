using System;

namespace DataAccessLayer.Models
{
    public class UserPassword: BaseModel
    {
        public Guid UserId { get; set; }
        public byte[] Salt { get; set; }
        public byte[] Hash { get; set; }
    }
}
