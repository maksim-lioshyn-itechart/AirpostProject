using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DataAccess.Interfaces;

namespace DataAccess.Interfaces
{
    public interface IDocumentRepository : IBaseRepository<DocumentEntity>
    {
        Task<IEnumerable<DocumentEntity>> GetBy(
            Guid? documentTypeId = null, 
            string name = null,
            string number = null,
            bool isActive = true);

        Task<DocumentEntity> GetBy(
            Guid documentTypeId,
            string name,
            string number,
            bool isActive = true);
    }
}