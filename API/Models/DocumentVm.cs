using System;

namespace API.Models
{
    public class DocumentViewModel : BaseViewModel
    {
        public Guid DocumentTypeId { get; set; }
        public string Name { get; set; }
        public string Number { get; set; }
        public bool IsActive { get; set; }
    }
}
