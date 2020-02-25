using BusinessLogicLayer.Interfaces;
using BusinessLogicLayer.Models;
using DataAccessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static BusinessLogicLayer.Mappers.CommonMapper;

namespace BusinessLogicLayer.Services
{
    public class CountryService : ICountryService
    {
        private IUnitOfWork UnitOfWork { get; }

        public CountryService(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }

        public async Task<bool> Create(CountryBm entity)
        {
            var countries = await UnitOfWork.Country.GetAll();
            if (countries.FirstOrDefault(country => country.Name == entity.Name) != null)
            {
                return false;
            }
            await UnitOfWork.Country.Create(entity.ToDal());
            return true;
        }

        public async Task Update(CountryBm entity)
        {
            var country = await UnitOfWork.Country.GetById(entity.Id);
            if (country != null)
            {
                await UnitOfWork.Country.Update(entity.ToDal());
            }
        }

        public async Task Delete(CountryBm entity)
        {
            var country = await UnitOfWork.Country.GetById(entity.Id);
            if (country != null)
            {
                await UnitOfWork.Country.Delete(entity.Id);
            }
        }

        public async Task<IEnumerable<CountryBm>> GetAll() =>
            (await UnitOfWork.Country.GetAll())
            .Select(country => country.ToBm());

        public async Task<CountryBm> GetById(Guid id) =>
            (await UnitOfWork.Country.GetById(id)).ToBm();
    }
}
