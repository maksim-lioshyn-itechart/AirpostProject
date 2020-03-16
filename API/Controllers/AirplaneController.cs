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
    public class AirplaneController : ControllerBase
    {
        private readonly IAirplaneService _airplaneService;
        private readonly ILogger<AirplaneController> _logger;

        public AirplaneController(
            IAirplaneService airplaneService,
            ILogger<AirplaneController> logger
            )
        {
            _airplaneService = airplaneService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IEnumerable<AirplaneViewModel>> Get()
        {
            return (await _airplaneService.GetAll()).Select(ur => ur.ToViewModel());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AirplaneViewModel>> Get(Guid id)
        {
            var user = (await _airplaneService.GetById(id)).ToViewModel();
            if (user == null)
            {
                _logger.LogInformation($"Airplane id = {id} not found.");
                return NotFound();
            }
            return new ObjectResult(user);
        }

        [HttpPut]
        public async Task<ActionResult<AirplaneViewModel>> Update(AirplaneViewModel airplane)
        {
            var response = await _airplaneService.Update(airplane.ToModel());
            if (response != BusinessLogic.Enums.StatusCode.Updated)
            {
                _logger.LogError($"Airplane {airplane.Name} not Updated.");
            }

            return response == BusinessLogic.Enums.StatusCode.Created
                ? (ActionResult<AirplaneViewModel>)Ok()
                : Conflict();
        }

        [HttpPost]
        public async Task<ActionResult<AirplaneViewModel>> Post(AirplaneViewModel airplane)
        {
            var response = await _airplaneService.Create(airplane.ToModel());
            if (response != BusinessLogic.Enums.StatusCode.Created)
            {
                _logger.LogError($"Airplane {airplane.Name} not Created.");
            }

            return response == BusinessLogic.Enums.StatusCode.Created
                ? (ActionResult<AirplaneViewModel>)Ok()
                : Conflict();
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<AirplaneViewModel>> Delete(Guid id)
        {
            var airplane = await _airplaneService.GetById(id);
            if (airplane == null)
            {
                _logger.LogInformation($"Airplane id = {id} not found.");
                return NotFound();
            }

            await _airplaneService.Delete(airplane);
            return Ok(airplane);
        }
    }
}
