using ORM.Attributes;
using System;

namespace ORM.Models
{
    [AirportTable(Name = "ContactInformation")]
    public class ContactInformation: BasicModel
    {
        [AirportColumn(Name = "UserId")]
        public Guid UserId { get; set; }
        [AirportColumn(Name = "Phone")]
        public string Phone { get; set; }
        [AirportColumn(Name = "Address")]
        public string Address { get; set; }
        [AirportColumn(Name = "Email")]
        public string Email { get; set; }
    }
}
