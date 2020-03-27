using DataAccess.Models;
using System.Threading.Tasks;

namespace DataAccess.Interfaces
{
    public interface ICountryRepository : IBaseRepository<CountryEntity>
    {
        Task<CountryEntity> GetBy(string name);
    }
}