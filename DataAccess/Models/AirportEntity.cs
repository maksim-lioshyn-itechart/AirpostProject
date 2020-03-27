using System;

namespace DataAccess.Models
{
    public class AirportEntity : BaseEntity
    {
        public Guid CountryId { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
    }
}
