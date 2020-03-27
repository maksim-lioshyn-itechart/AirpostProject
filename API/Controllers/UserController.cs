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
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly ILogger<UserController> _logger;

        public UserController(
            IUserService userService,
            ILogger<UserController> logger
            )
        {
            _userService = userService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IEnumerable<UserViewModel>> Get()
        {
            return (await _userService.GetAll()).Select(ur => ur.ToViewModel());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserViewModel>> Get(Guid id)
        {
            var user = (await _userService.GetById(id)).ToViewModel();
            if (user == null)
            {
                _logger.LogInformation($"User id = {id} not found.");
                return NotFound();
            }
            return new ObjectResult(user);
        }

        [HttpPut]
        public async Task<ActionResult<UserViewModel>> Update(UserViewModel user)
        {
            var response = await _userService.Update(user.ToModel());
            if (response != BusinessLogic.Enums.StatusCode.Updated)
            {
                _logger.LogError($"User not updated.");
            }

            return response == BusinessLogic.Enums.StatusCode.Created
                ? (ActionResult<UserViewModel>)Ok()
                : Conflict();
        }

        [HttpPost]
        public async Task<ActionResult<UserViewModel>> Post(UserViewModel user)
        {
            var response = await _userService.Create(user.ToModel());
            if (response != BusinessLogic.Enums.StatusCode.Created)
            {
                _logger.LogError($"User not created.");
            }

            return response == BusinessLogic.Enums.StatusCode.Created
                ? (ActionResult<UserViewModel>)Ok()
                : Conflict();
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<UserViewModel>> Delete(Guid id)
        {
            var user = await _userService.GetById(id);
            if (user == null)
            {
                _logger.LogInformation($"User id = {id} not found.");
                return NotFound();
            }

            await _userService.Delete(user);
            return Ok(user);
        }
    }
}
