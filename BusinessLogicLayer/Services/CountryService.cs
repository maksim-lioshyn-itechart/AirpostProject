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
        private ICountryRepository Country { get; }

        public CountryService(ICountryRepository country)
        {
            Country = country;
        }

        public async Task<bool> Create(Country entity)
        {
            var countries = await Country.GetAll();
            if (countries.FirstOrDefault(country => country.Name == entity.Name) != null)
            {
                return false;
            }
            await Country.Create(entity.ToEntity());
            return true;
        }

        public async Task Update(Country entity)
        {
            var country = await Country.GetById(entity.Id);
            if (country != null)
            {
                await Country.Update(entity.ToEntity());
            }
        }

        public async Task Delete(Country entity)
        {
            var country = await Country.GetById(entity.Id);
            if (country != null)
            {
                await Country.Delete(entity.Id);
            }
        }

        public async Task<IEnumerable<Country>> GetAll() =>
            (await Country.GetAll())
            .Select(country => country.ToModel());

        public async Task<Country> GetById(Guid id) =>
            (await Country.GetById(id)).ToModel();
    }
}
