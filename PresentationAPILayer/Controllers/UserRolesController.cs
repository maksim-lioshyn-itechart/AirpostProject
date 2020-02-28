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
        public IEnumerable<UserRoleViewModel> Get()
        {
            return _userRoleService.GetAll().Result.Select(ur=>ur.ToViewModel());
        }
    }
}
