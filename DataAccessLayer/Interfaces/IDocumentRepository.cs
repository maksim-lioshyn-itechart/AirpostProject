using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccessLayer.Interfaces
{
    public interface IDocumentRepository : IBaseRepository<DocumentEntity>
    {
        Task<IEnumerable<DocumentEntity>> GetDocumentsByDocumentTypeId(Guid documentTypeId, bool isActive = true);
    }
}