using DataAccessLayer.Interfaces;
using ORM.Models;

namespace DataAccessLayer.Repositories
{
    public class CountryRepository: BaseRepository<Country>, ICountryRepository
    {
        public CountryRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}
