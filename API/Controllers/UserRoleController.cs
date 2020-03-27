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
    public class UserRoleController : ControllerBase
    {
        private readonly IUserRoleService _userRoleService;
        private readonly ILogger<UserRoleController> _logger;

        public UserRoleController(
            IUserRoleService userRoleService,
            ILogger<UserRoleController> logger
            )
        {
            _userRoleService = userRoleService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IEnumerable<UserRoleViewModel>> Get()
        {
            return (await _userRoleService.GetAll()).Select(ur => ur.ToViewModel());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserRoleViewModel>> Get(Guid id)
        {
            var user = (await _userRoleService.GetById(id)).ToViewModel();
            if (user == null)
            {
                _logger.LogInformation($"UserRole id = {id} not found.");
                return NotFound();
            }
            return new ObjectResult(user);
        }

        [HttpPut]
        public async Task<ActionResult<UserRoleViewModel>> Update(UserRoleViewModel userRole)
        {
            var response = await _userRoleService.Update(userRole.ToModel());
            if (response != BusinessLogic.Enums.StatusCode.Updated)
            {
                _logger.LogError($"UserRole {userRole.Name} not found.");
            }

            return response == BusinessLogic.Enums.StatusCode.Created
                ? (ActionResult<UserRoleViewModel>)Ok()
                : Conflict();
        }

        [HttpPost]
        public async Task<ActionResult<UserRoleViewModel>> Post(UserRoleViewModel userRole)
        {
            var response = await _userRoleService.Create(userRole.ToModel());
            if (response != BusinessLogic.Enums.StatusCode.Created)
            {
                _logger.LogError($"UserRole {userRole.Name} not found.");
            }

            return response == BusinessLogic.Enums.StatusCode.Created
                ? (ActionResult<UserRoleViewModel>)Ok()
                : Conflict();
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<UserRoleViewModel>> Delete(Guid id)
        {
            var userRole = await _userRoleService.GetById(id);
            if (userRole == null)
            {
                _logger.LogInformation($"UserRole id = {id} not found.");
                return NotFound();
            }

            await _userRoleService.Delete(userRole);
            return Ok(userRole);
        }
    }
}
