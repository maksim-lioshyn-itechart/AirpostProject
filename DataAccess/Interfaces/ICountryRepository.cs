using System.Collections.Generic;
using System.Threading.Tasks;
using DataAccess.Interfaces;
using DataAccess.Models;

namespace DataAccess.Interfaces
{
    public interface ICountryRepository : IBaseRepository<CountryEntity>
    {
        Task<CountryEntity> GetBy(string name);
    }
}