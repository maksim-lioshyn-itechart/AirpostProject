using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccessLayer.Interfaces
{
    public interface IDocumentRepository : IBaseRepository<DocumentEntity>
    {
        Task<IEnumerable<DocumentEntity>> GetBy(
            Guid? documentTypeId = null, 
            string name = null,
            string number = null,
            bool isActive = true);
    }
}