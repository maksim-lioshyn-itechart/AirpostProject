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
    public class AirplaneTypeController : ControllerBase
    {
        private readonly IAirplaneTypeService _airplaneTypeService;
        private readonly ILogger<AirplaneTypeController> _logger;

        public AirplaneTypeController(
            IAirplaneTypeService airplaneTypeService,
            ILogger<AirplaneTypeController> logger
            )
        {
            _airplaneTypeService = airplaneTypeService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IEnumerable<AirplaneTypeViewModel>> Get()
        {
            return (await _airplaneTypeService.GetAll()).Select(ur => ur.ToViewModel());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AirplaneTypeViewModel>> Get(Guid id)
        {
            var user = (await _airplaneTypeService.GetById(id)).ToViewModel();
            if (user == null)
            {
                _logger.LogInformation($"AirplaneType id = {id} not found.");
                return NotFound();
            }
            return new ObjectResult(user);
        }

        [HttpPut]
        public async Task<ActionResult<AirplaneTypeViewModel>> Update(AirplaneTypeViewModel airplaneType)
        {
            var response = await _airplaneTypeService.Update(airplaneType.ToModel());
            if (response != BusinessLogic.Enums.StatusCode.Updated)
            {
                _logger.LogError($"AirplaneType {airplaneType.Name} not Updated.");
            }

            return response == BusinessLogic.Enums.StatusCode.Created
                ? (ActionResult<AirplaneTypeViewModel>)Ok()
                : Conflict();
        }

        [HttpPost]
        public async Task<ActionResult<AirplaneTypeViewModel>> Post(AirplaneTypeViewModel airplaneType)
        {
            var response = await _airplaneTypeService.Create(airplaneType.ToModel());
            if (response != BusinessLogic.Enums.StatusCode.Created)
            {
                _logger.LogError($"AirplaneType {airplaneType.Name} not Created.");
            }

            return response == BusinessLogic.Enums.StatusCode.Created
                ? (ActionResult<AirplaneTypeViewModel>)Ok()
                : Conflict();
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<AirplaneTypeViewModel>> Delete(Guid id)
        {
            var airplaneType = await _airplaneTypeService.GetById(id);
            if (airplaneType == null)
            {
                _logger.LogInformation($"AirplaneType id = {id} not found.");
                return NotFound();
            }

            await _airplaneTypeService.Delete(airplaneType);
            return Ok(airplaneType);
        }
    }
}
