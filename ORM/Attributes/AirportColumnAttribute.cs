using System;

namespace ORM.Attributes
{
    [AttributeUsage( AttributeTargets.Property)]
    public class AirportColumnAttribute: Attribute
    {
        public string Name { get; set; }
        public string Length { get; set; }
    }
}
