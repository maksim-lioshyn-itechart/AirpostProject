using System;

namespace DataAccessLayer.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class ColumnAttribute: Attribute
    {
        public string Name { get; set; }
        public string Length { get; set; }
    }
}
