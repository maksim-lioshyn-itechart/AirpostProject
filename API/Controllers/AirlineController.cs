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
    public class AirlineController : ControllerBase
    {
        private readonly IAirlineService _airlineService;
        private readonly ILogger<AirlineController> _logger;

        public AirlineController(
            IAirlineService airlineService,
            ILogger<AirlineController> logger
            )
        {
            _airlineService = airlineService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IEnumerable<AirlineViewModel>> Get()
        {
            return (await _airlineService.GetAll()).Select(ur => ur.ToViewModel());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AirlineViewModel>> Get(Guid id)
        {
            var user = (await _airlineService.GetById(id)).ToViewModel();
            if (user == null)
            {
                _logger.LogInformation($"Airline id = {id} not found.");
                return NotFound();
            }
            return new ObjectResult(user);
        }

        [HttpPut]
        public async Task<ActionResult<AirlineViewModel>> Update(AirlineViewModel airline)
        {
            var response = await _airlineService.Update(airline.ToModel());
            if (response != BusinessLogic.Enums.StatusCode.Updated)
            {
                _logger.LogError($"Airline {airline.Name} not Updated.");
            }

            return response == BusinessLogic.Enums.StatusCode.Created
                ? (ActionResult<AirlineViewModel>)Ok()
                : Conflict();
        }

        [HttpPost]
        public async Task<ActionResult<AirlineViewModel>> Post(AirlineViewModel airline)
        {
            var response = await _airlineService.Create(airline.ToModel());
            if (response != BusinessLogic.Enums.StatusCode.Created)
            {
                _logger.LogError($"Airline {airline.Name} not Created.");
            }

            return response == BusinessLogic.Enums.StatusCode.Created
                ? (ActionResult<AirlineViewModel>)Ok()
                : Conflict();
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<AirlineViewModel>> Delete(Guid id)
        {
            var airline = await _airlineService.GetById(id);
            if (airline == null)
            {
                _logger.LogInformation($"Airline id = {id} not found.");
                return NotFound();
            }

            await _airlineService.Delete(airline);
            return Ok(airline);
        }
    }
}
