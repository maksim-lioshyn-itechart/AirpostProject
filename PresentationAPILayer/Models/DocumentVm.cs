using System;

namespace PresentationAPILayer.Models
{
    public class DocumentVm : BaseVm
    {
        public Guid DocumentTypeId { get; set; }
        public string Name { get; set; }
        public string Number { get; set; }
        public bool IsActive { get; set; }
    }
}
