using BusinessLogicLayer.Interfaces;
using Microsoft.AspNetCore.Mvc;
using PresentationAPILayer.Mappers;
using PresentationAPILayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PresentationAPILayer.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private readonly ICountryService _countryService;

        public CountryController(ICountryService countryService)
        {
            _countryService = countryService;
        }

        [HttpGet]
        public async Task<IEnumerable<CountryViewModel>> Get()
        {
            return (await _countryService.GetAll()).Select(ur => ur.ToViewModel());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CountryViewModel>> Get(Guid id)
        {
            var user = (await _countryService.GetById(id)).ToViewModel();
            if (user == null)
                return NotFound();
            return new ObjectResult(user);
        }

        [HttpPut]
        public async Task<ActionResult<CountryViewModel>> Update(CountryViewModel country)
        {
            if (country == null)
            {
                return BadRequest();
            }
            await _countryService.Update(country.ToModel());
            return Ok();
        }

        [HttpPost]
        public async Task<ActionResult<CountryViewModel>> Post(CountryViewModel model)
        {
            if (model == null)
            {
                return Conflict();
            }

            var response = await _countryService.Create(model.ToModel());
            return response == BusinessLogicLayer.enums.StatusCode.Created
                ? (ActionResult<CountryViewModel>)Ok()
                : Conflict();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<CountryViewModel>> Delete(Guid id)
        {
            var country = await _countryService.GetById(id);
            if (country == null)
            {
                return NotFound();
            }

            await _countryService.Delete(country);
            return Ok(country);
        }
    }
}
