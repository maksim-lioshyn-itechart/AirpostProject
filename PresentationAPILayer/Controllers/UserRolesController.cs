using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLogicLayer.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PresentationAPILayer.Models;
using static PresentationAPILayer.Mappers.CommonMapper;

namespace PresentationAPILayer.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserRolesController : ControllerBase
    {
        private readonly IUserRoleService _userRoleService;

        public UserRolesController(IUserRoleService userRoleService)
        {
            _userRoleService = userRoleService;
        }

        [HttpGet]
        public async Task<IEnumerable<UserRoleViewModel>> Get()
        {
            return (await _userRoleService.GetAll()).Select(ur=>ur.ToViewModel());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserRoleViewModel>> Get(Guid id)
        {
            UserRoleViewModel user = (await _userRoleService.GetById(id)).ToViewModel();
            if (user == null)
                return NotFound();
            return new ObjectResult(user);
        }

        // PUT api/users/
        [HttpPut]
        public async Task<ActionResult<UserRoleViewModel>> Put(UserRoleViewModel userRole)
        {
            if (userRole == null)
            {
                return BadRequest();
            }
            await _userRoleService.Update(userRole.ToModel());
            return Ok(userRole);
        }

        // DELETE api/users/5
        [HttpDelete("{id}")]
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
