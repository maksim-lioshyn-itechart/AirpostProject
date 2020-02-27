using System;

namespace DataAccessLayer.Models
{
    public class DocumentEntity : BaseEntity
    {
        public Guid DocumentTypeId { get; set; }
        public string Name { get; set; }
        public string Number { get; set; }
        public bool IsActive { get; set; }
    }
}
