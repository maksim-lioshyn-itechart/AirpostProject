using API.Models;
using BusinessLogic.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static API.Mappers.CommonMapper;

namespace API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private readonly ICountryService _countryService;
        private readonly ILogger<CountryController> _logger;

        public CountryController(
            ICountryService countryService,
            ILogger<CountryController> logger
            )
        {
            _countryService = countryService;
            _logger = logger;
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
            {
                _logger.LogInformation($"Country id = {id} not found.");
                return NotFound();
            }
            return new ObjectResult(user);
        }

        [HttpPut]
        public async Task<ActionResult<CountryViewModel>> Update(CountryViewModel country)
        {
            var response = await _countryService.Update(country.ToModel());
            if (response != BusinessLogic.Enums.StatusCode.Updated)
            {
                _logger.LogError($"Country {country.Name} not Updated.");
            }

            return response == BusinessLogic.Enums.StatusCode.Created
                ? (ActionResult<CountryViewModel>)Ok()
                : Conflict();
        }

        [HttpPost]
        public async Task<ActionResult<CountryViewModel>> Post(CountryViewModel country)
        {
            var response = await _countryService.Create(country.ToModel());
            if (response != BusinessLogic.Enums.StatusCode.Created)
            {
                _logger.LogError($"Country {country.Name} not Created.");
            }

            return response == BusinessLogic.Enums.StatusCode.Created
                ? (ActionResult<CountryViewModel>)Ok()
                : Conflict();
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<CountryViewModel>> Delete(Guid id)
        {
            var country = await _countryService.GetById(id);
            if (country == null)
            {
                _logger.LogInformation($"Country id = {id} not found.");
                return NotFound();
            }

            await _countryService.Delete(country);
            return Ok(country);
        }
    }
}
