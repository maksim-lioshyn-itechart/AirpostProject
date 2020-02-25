using System;

namespace DataAccessLayer.Models
{
    public class Document : BaseModel
    {
        public Guid DocumentTypeId { get; set; }
        public string Name { get; set; }
        public string Number { get; set; }
    }
}
