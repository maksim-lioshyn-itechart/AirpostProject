using DataAccess.Models;
using System.Threading.Tasks;

namespace DataAccess.Interfaces
{
    public interface IDocumentTypeRepository : IBaseRepository<DocumentTypeEntity>
    {
        Task<DocumentTypeEntity> GetBy(string name);
    }
}
