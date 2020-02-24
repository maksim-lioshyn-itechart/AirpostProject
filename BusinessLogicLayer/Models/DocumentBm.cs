using System;

namespace BusinessLogicLayer.Models
{
    public class DocumentBm: BaseBm
    {
        public Guid DocumentTypeId { get; set; }
        public string Name { get; set; }
        public string Number { get; set; }
        public bool IsActive { get; set; }
    }
}
