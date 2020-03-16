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
    public class AirplaneSubTypeController : ControllerBase
    {
        private readonly IAirplaneSubTypeService _airplaneSubTypeService;
        private readonly ILogger<AirplaneSubTypeController> _logger;

        public AirplaneSubTypeController(
            IAirplaneSubTypeService airplaneSubTypeService,
            ILogger<AirplaneSubTypeController> logger
            )
        {
            _airplaneSubTypeService = airplaneSubTypeService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IEnumerable<AirplaneSubTypeViewModel>> Get()
        {
            return (await _airplaneSubTypeService.GetAll()).Select(ur => ur.ToViewModel());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AirplaneSubTypeViewModel>> Get(Guid id)
        {
            var user = (await _airplaneSubTypeService.GetById(id)).ToViewModel();
            if (user == null)
            {
                _logger.LogInformation($"AirplaneSubType id = {id} not found.");
                return NotFound();
            }
            return new ObjectResult(user);
        }

        [HttpPut]
        public async Task<ActionResult<AirplaneSubTypeViewModel>> Update(AirplaneSubTypeViewModel airplaneSubType)
        {
            var response = await _airplaneSubTypeService.Update(airplaneSubType.ToModel());
            if (response != BusinessLogic.Enums.StatusCode.Updated)
            {
                _logger.LogError($"AirplaneSubType {airplaneSubType.Name} not Updated.");
            }

            return response == BusinessLogic.Enums.StatusCode.Created
                ? (ActionResult<AirplaneSubTypeViewModel>)Ok()
                : Conflict();
        }

        [HttpPost]
        public async Task<ActionResult<AirplaneSubTypeViewModel>> Post(AirplaneSubTypeViewModel airplaneSubType)
        {
            var response = await _airplaneSubTypeService.Create(airplaneSubType.ToModel());
            if (response != BusinessLogic.Enums.StatusCode.Created)
            {
                _logger.LogError($"AirplaneSubType {airplaneSubType.Name} not Created.");
            }

            return response == BusinessLogic.Enums.StatusCode.Created
                ? (ActionResult<AirplaneSubTypeViewModel>)Ok()
                : Conflict();
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<AirplaneSubTypeViewModel>> Delete(Guid id)
        {
            var airplaneSubType = await _airplaneSubTypeService.GetById(id);
            if (airplaneSubType == null)
            {
                _logger.LogInformation($"AirplaneSubType id = {id} not found.");
                return NotFound();
            }

            await _airplaneSubTypeService.Delete(airplaneSubType);
            return Ok(airplaneSubType);
        }
    }
}
