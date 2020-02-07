using ORM.Attributes;

namespace ORM.Models
{
    [AirportTable(Name = "Roles")]
    public class Role: BasicModel
    {
        [AirportColumn(Name = "Name")]
        public string Name { get; set; }
    }
}
