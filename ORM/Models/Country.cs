using ORM.Attributes;

namespace ORM.Models
{
    [AirportTable(Name = "Countries")]
    public class Country: BasicModel
    {
        [AirportColumn(Name = "Name")]
        public string Name { get; set; }
        [AirportColumn(Name = "Code")]
        public string Code { get; set; }
    }
}
