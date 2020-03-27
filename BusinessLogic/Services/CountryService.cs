using BusinessLogic.Enums;
using BusinessLogic.Interfaces;
using BusinessLogic.Models;
using DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static BusinessLogic.Mappers.CommonMapper;

namespace BusinessLogic.Services
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
            Validation(entity);
            var countries = await Country.GetBy(entity.Name);
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
                Validation(entity);
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

        private void Validation(Country entity)
        {
            var validator = new Validator<Country>();
            validator.IsValidName(entity.Name);
        }
    }
}
