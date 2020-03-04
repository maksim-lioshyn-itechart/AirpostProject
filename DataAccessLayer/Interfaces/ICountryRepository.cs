using System.Collections.Generic;
using System.Threading.Tasks;
using DataAccessLayer.Models;

namespace DataAccessLayer.Interfaces
{
    public interface ICountryRepository : IBaseRepository<CountryEntity>
    {
        Task<CountryEntity> GetBy(string name);
    }
}