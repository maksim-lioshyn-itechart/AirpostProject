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
    public class AirplaneSchemaController : ControllerBase
    {
        private readonly IAirplaneSchemaService _airplaneSchemaService;
        private readonly ILogger<AirplaneSchemaController> _logger;

        public AirplaneSchemaController(
            IAirplaneSchemaService airplaneSchemaService,
            ILogger<AirplaneSchemaController> logger
            )
        {
            _airplaneSchemaService = airplaneSchemaService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IEnumerable<AirplaneSchemaViewModel>> Get()
        {
            return (await _airplaneSchemaService.GetAll()).Select(ur => ur.ToViewModel());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AirplaneSchemaViewModel>> Get(Guid id)
        {
            var user = (await _airplaneSchemaService.GetById(id)).ToViewModel();
            if (user == null)
            {
                _logger.LogInformation($"AirplaneSchema id = {id} not found.");
                return NotFound();
            }
            return new ObjectResult(user);
        }

        [HttpPut]
        public async Task<ActionResult<AirplaneSchemaViewModel>> Update(AirplaneSchemaViewModel airplaneSchema)
        {
            var response = await _airplaneSchemaService.Update(airplaneSchema.ToModel());
            if (response != BusinessLogic.Enums.StatusCode.Updated)
            {
                _logger.LogError($"AirplaneSchema {airplaneSchema.Name} not Updated.");
            }

            return response == BusinessLogic.Enums.StatusCode.Created
                ? (ActionResult<AirplaneSchemaViewModel>)Ok()
                : Conflict();
        }

        [HttpPost]
        public async Task<ActionResult<AirplaneSchemaViewModel>> Post(AirplaneSchemaViewModel airplaneSchema)
        {
            var response = await _airplaneSchemaService.Create(airplaneSchema.ToModel());
            if (response != BusinessLogic.Enums.StatusCode.Created)
            {
                _logger.LogError($"AirplaneSchema {airplaneSchema.Name} not Created.");
            }

            return response == BusinessLogic.Enums.StatusCode.Created
                ? (ActionResult<AirplaneSchemaViewModel>)Ok()
                : Conflict();
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<AirplaneSchemaViewModel>> Delete(Guid id)
        {
            var airplaneSchema = await _airplaneSchemaService.GetById(id);
            if (airplaneSchema == null)
            {
                _logger.LogInformation($"AirplaneSchema id = {id} not found.");
                return NotFound();
            }

            await _airplaneSchemaService.Delete(airplaneSchema);
            return Ok(airplaneSchema);
        }
    }
}
