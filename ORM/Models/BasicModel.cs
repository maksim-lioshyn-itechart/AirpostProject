using System;
using ORM.Attributes;

namespace ORM.Models
{
    public class BasicModel
    {
        [AirportColumn(Name = "Id")]
        public Guid Id { get; set; }
    }
}
