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
    public class PassengerSeatController : ControllerBase
    {
        private readonly IPassengerSeatService _passengerSeatService;
        private readonly ILogger<PassengerSeatController> _logger;

        public PassengerSeatController(
            IPassengerSeatService passengerSeatService,
            ILogger<PassengerSeatController> logger
            )
        {
            _passengerSeatService = passengerSeatService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IEnumerable<PassengerSeatViewModel>> Get()
        {
            return (await _passengerSeatService.GetAll()).Select(ur => ur.ToViewModel());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PassengerSeatViewModel>> Get(Guid id)
        {
            var user = (await _passengerSeatService.GetById(id)).ToViewModel();
            if (user == null)
            {
                _logger.LogInformation($"PassengerSeat id = {id} not found.");
                return NotFound();
            }
            return new ObjectResult(user);
        }

        [HttpPut]
        public async Task<ActionResult<PassengerSeatViewModel>> Update(PassengerSeatViewModel passengerSeat)
        {
            var response = await _passengerSeatService.Update(passengerSeat.ToModel());
            if (response != BusinessLogic.Enums.StatusCode.Updated)
            {
                _logger.LogError($"PassengerSeat not updated.");
            }

            return response == BusinessLogic.Enums.StatusCode.Created
                ? (ActionResult<PassengerSeatViewModel>)Ok()
                : Conflict();
        }

        [HttpPost]
        public async Task<ActionResult<PassengerSeatViewModel>> Post(PassengerSeatViewModel passengerSeat)
        {
            var response = await _passengerSeatService.Create(passengerSeat.ToModel());
            if (response != BusinessLogic.Enums.StatusCode.Created)
            {
                _logger.LogError($"PassengerSeat not created.");
            }

            return response == BusinessLogic.Enums.StatusCode.Created
                ? (ActionResult<PassengerSeatViewModel>)Ok()
                : Conflict();
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<PassengerSeatViewModel>> Delete(Guid id)
        {
            var passengerSeat = await _passengerSeatService.GetById(id);
            if (passengerSeat == null)
            {
                _logger.LogInformation($"PassengerSeat id = {id} not found.");
                return NotFound();
            }

            await _passengerSeatService.Delete(passengerSeat);
            return Ok(passengerSeat);
        }
    }
}
