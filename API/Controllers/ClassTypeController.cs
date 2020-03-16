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
    public class ClassTypeController : ControllerBase
    {
        private readonly IClassTypeService _classTypeService;
        private readonly ILogger<ClassTypeController> _logger;

        public ClassTypeController(
            IClassTypeService classTypeService,
            ILogger<ClassTypeController> logger
            )
        {
            _classTypeService = classTypeService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IEnumerable<ClassTypeViewModel>> Get()
        {
            return (await _classTypeService.GetAll()).Select(ur => ur.ToViewModel());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ClassTypeViewModel>> Get(Guid id)
        {
            var user = (await _classTypeService.GetById(id)).ToViewModel();
            if (user == null)
            {
                _logger.LogInformation($"ClassType id = {id} not found.");
                return NotFound();
            }
            return new ObjectResult(user);
        }

        [HttpPut]
        public async Task<ActionResult<ClassTypeViewModel>> Update(ClassTypeViewModel classType)
        {
            var response = await _classTypeService.Update(classType.ToModel());
            if (response != BusinessLogic.Enums.StatusCode.Updated)
            {
                _logger.LogError($"ClassType {classType.Name} not Updated.");
            }

            return response == BusinessLogic.Enums.StatusCode.Created
                ? (ActionResult<ClassTypeViewModel>)Ok()
                : Conflict();
        }

        [HttpPost]
        public async Task<ActionResult<ClassTypeViewModel>> Post(ClassTypeViewModel classType)
        {
            var response = await _classTypeService.Create(classType.ToModel());
            if (response != BusinessLogic.Enums.StatusCode.Created)
            {
                _logger.LogError($"ClassType {classType.Name} not Created.");
            }

            return response == BusinessLogic.Enums.StatusCode.Created
                ? (ActionResult<ClassTypeViewModel>)Ok()
                : Conflict();
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<ClassTypeViewModel>> Delete(Guid id)
        {
            var classType = await _classTypeService.GetById(id);
            if (classType == null)
            {
                _logger.LogInformation($"ClassType id = {id} not found.");
                return NotFound();
            }

            await _classTypeService.Delete(classType);
            return Ok(classType);
        }
    }
}
