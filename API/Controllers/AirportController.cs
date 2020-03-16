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
    public class AirportController : ControllerBase
    {
        private readonly IAirportService _airportService;
        private readonly ILogger<AirportController> _logger;

        public AirportController(
            IAirportService airportService,
            ILogger<AirportController> logger
            )
        {
            _airportService = airportService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IEnumerable<AirportViewModel>> Get()
        {
            return (await _airportService.GetAll()).Select(ur => ur.ToViewModel());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AirportViewModel>> Get(Guid id)
        {
            var user = (await _airportService.GetById(id)).ToViewModel();
            if (user == null)
            {
                _logger.LogInformation($"Airport id = {id} not found.");
                return NotFound();
            }
            return new ObjectResult(user);
        }

        [HttpPut]
        public async Task<ActionResult<AirportViewModel>> Update(AirportViewModel airport)
        {
            var response = await _airportService.Update(airport.ToModel());
            if (response != BusinessLogic.Enums.StatusCode.Updated)
            {
                _logger.LogError($"Airport {airport.Name} not Updated.");
            }

            return response == BusinessLogic.Enums.StatusCode.Created
                ? (ActionResult<AirportViewModel>)Ok()
                : Conflict();
        }

        [HttpPost]
        public async Task<ActionResult<AirportViewModel>> Post(AirportViewModel airport)
        {
            var response = await _airportService.Create(airport.ToModel());
            if (response != BusinessLogic.Enums.StatusCode.Created)
            {
                _logger.LogError($"Airport {airport.Name} not Created.");
            }

            return response == BusinessLogic.Enums.StatusCode.Created
                ? (ActionResult<AirportViewModel>)Ok()
                : Conflict();
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<AirportViewModel>> Delete(Guid id)
        {
            var airport = await _airportService.GetById(id);
            if (airport == null)
            {
                _logger.LogInformation($"Airport id = {id} not found.");
                return NotFound();
            }

            await _airportService.Delete(airport);
            return Ok(airport);
        }
    }
}
