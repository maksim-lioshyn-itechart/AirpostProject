using BusinessLogicLayer.Interfaces;
using BusinessLogicLayer.Models;
using DataAccessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLogicLayer.enums;
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

        public async Task<StatusCode> Create(Country entity)
        {
            var countries = (await Country.GetBy(entity.Name)).FirstOrDefault();
            var isExist = countries != null;

            if (isExist)
            {
                return StatusCode.AlreadyExists;
            }

            await Country.Create(entity.ToEntity());
            return StatusCode.Created;
        }

        public async Task<StatusCode> Update(Country entity)
        {
            var country = await Country.GetById(entity.Id);
            if (country != null)
            {
                await Country.Update(entity.ToEntity());
                return StatusCode.Updated;
            }
            return StatusCode.DoesNotExist;
        }

        public async Task<StatusCode> Delete(Country entity)
        {
            var country = await Country.GetById(entity.Id);
            if (country != null)
            {
                await Country.Delete(entity.Id);
                return StatusCode.Deleted;
            }
            return StatusCode.DoesNotExist;
        }

        public async Task<IEnumerable<Country>> GetAll() =>
            (await Country.GetAll())
            .Select(country => country.ToModel());

        public async Task<Country> GetById(Guid id) =>
            (await Country.GetById(id))?.ToModel();
    }
}
