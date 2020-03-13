using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLogic.Interfaces;
using Microsoft.AspNetCore.Mvc;
using API.Models;
using Microsoft.Extensions.Logging;
using static API.Mappers.CommonMapper;

namespace API.Controllers
{
    [Route("[controller]/[action]")]
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
                return NotFound();
            }
            return new ObjectResult(user);
        }

        [HttpPut]
        public async Task<ActionResult<UserRoleViewModel>> Update(UserRoleViewModel userRole)
        {
            if (userRole == null)
            {
                return BadRequest();
            }

            var response = await _userRoleService.Update(userRole.ToModel());
            return response == BusinessLogic.Enums.StatusCode.Created
                ? (ActionResult<UserRoleViewModel>)Ok()
                : Conflict();
        }

        [HttpPost]
        public async Task<ActionResult<UserRoleViewModel>> Post(UserRoleViewModel model)
        {
            if (model == null)
            {
                return Conflict();
            }

            var response = await _userRoleService.Create(model.ToModel());
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
                return NotFound();
            }

            await _userRoleService.Delete(userRole);
            return Ok(userRole);
        }
    }
}
