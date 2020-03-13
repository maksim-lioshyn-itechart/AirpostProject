using System.Collections.Generic;
using System.Threading.Tasks;
using DataAccess.Interfaces;
using DataAccess.Models;

namespace DataAccess.Interfaces
{
    public interface IDocumentTypeRepository : IBaseRepository<DocumentTypeEntity>
    {
        Task<DocumentTypeEntity> GetBy(string name);
    }
}
