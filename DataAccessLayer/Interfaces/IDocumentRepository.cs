using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DataAccessLayer.Models;

namespace DataAccessLayer.Interfaces
{
    public interface IDocumentRepository: IBaseRepository<Document>
    {
        Task<IEnumerable<Document>> GetDocumentsByDocumentTypeId(Guid documentTypeId, bool isActive = true);
    }
}