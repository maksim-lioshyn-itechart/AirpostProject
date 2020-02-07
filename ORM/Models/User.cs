using System;
using ORM.Attributes;

namespace ORM.Models
{
    [AirportTable(Name ="Users")]
    public class User: BasicModel
    {
        [AirportColumn(Name = "FirstName")]
        public string FirstName { get; set; }
        [AirportColumn(Name = "LastName")]
        public string LastName { get; set; }
        [AirportColumn(Name = "Login")]
        public string Login { get; set; }
        [AirportColumn(Name = "Password")]
        public string Password { get; set; }
        public Guid? RoleId { get; set; }
    }
}
