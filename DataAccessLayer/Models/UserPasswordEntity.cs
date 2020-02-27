using System;

namespace DataAccessLayer.Models
{
    public class UserPasswordEntity : BaseEntity
    {
        public Guid UserId { get; set; }
        public byte[] Salt { get; set; }
        public byte[] Hash { get; set; }
    }
}
