using System;

namespace BusinessLogic.Models
{
    public class Airline : BaseModel
    {
        public Guid CountryId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string Url { get; set; }
    }
}
