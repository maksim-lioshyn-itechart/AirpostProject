using System;

namespace ORM.Attributes
{
    [AttributeUsage(AttributeTargets.Class)]
    public class AirportTableAttribute: Attribute
    {
        public string Name { get; set; }
    }
}
