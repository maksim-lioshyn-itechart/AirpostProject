using System.Collections.Generic;
using System.Threading.Tasks;
using DataAccessLayer.Models;

namespace DataAccessLayer.Interfaces
{
    public interface IDocumentTypeRepository : IBaseRepository<DocumentTypeEntity>
    {
        Task<IEnumerable<DocumentTypeEntity>> GetBy(string name);
    }
}
