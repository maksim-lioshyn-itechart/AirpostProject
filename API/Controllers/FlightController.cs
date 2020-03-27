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
    public class FlightController : ControllerBase
    {
        private readonly IFlightService _flightService;
        private readonly ILogger<FlightController> _logger;

        public FlightController(
            IFlightService flightService,
            ILogger<FlightController> logger
            )
        {
            _flightService = flightService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IEnumerable<FlightViewModel>> Get()
        {
            return (await _flightService.GetAll()).Select(ur => ur.ToViewModel());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<FlightViewModel>> Get(Guid id)
        {
            var user = (await _flightService.GetById(id)).ToViewModel();
            if (user == null)
            {
                _logger.LogInformation($"Flight id = {id} not found.");
                return NotFound();
            }
            return new ObjectResult(user);
        }

        [HttpPut]
        public async Task<ActionResult<FlightViewModel>> Update(FlightViewModel flight)
        {
            var response = await _flightService.Update(flight.ToModel());
            if (response != BusinessLogic.Enums.StatusCode.Updated)
            {
                _logger.LogError($"Flight not update.");
            }

            return response == BusinessLogic.Enums.StatusCode.Created
                ? (ActionResult<FlightViewModel>)Ok()
                : Conflict();
        }

        [HttpPost]
        public async Task<ActionResult<FlightViewModel>> Post(FlightViewModel flight)
        {
            var response = await _flightService.Create(flight.ToModel());
            if (response != BusinessLogic.Enums.StatusCode.Created)
            {
                _logger.LogError($"Flight not created.");
            }

            return response == BusinessLogic.Enums.StatusCode.Created
                ? (ActionResult<FlightViewModel>)Ok()
                : Conflict();
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<FlightViewModel>> Delete(Guid id)
        {
            var flight = await _flightService.GetById(id);
            if (flight == null)
            {
                _logger.LogInformation($"Flight id = {id} not found.");
                return NotFound();
            }

            await _flightService.Delete(flight);
            return Ok(flight);
        }
    }
}
