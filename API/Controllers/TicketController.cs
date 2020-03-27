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
    public class TicketController : ControllerBase
    {
        private readonly ITicketService _ticketService;
        private readonly ILogger<TicketController> _logger;

        public TicketController(
            ITicketService ticketService,
            ILogger<TicketController> logger
            )
        {
            _ticketService = ticketService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IEnumerable<TicketViewModel>> Get()
        {
            return (await _ticketService.GetAll()).Select(ur => ur.ToViewModel());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TicketViewModel>> Get(Guid id)
        {
            var user = (await _ticketService.GetById(id)).ToViewModel();
            if (user == null)
            {
                _logger.LogInformation($"Ticket id = {id} not found.");
                return NotFound();
            }
            return new ObjectResult(user);
        }

        [HttpPut]
        public async Task<ActionResult<TicketViewModel>> Update(TicketViewModel ticket)
        {
            var response = await _ticketService.Update(ticket.ToModel());
            if (response != BusinessLogic.Enums.StatusCode.Updated)
            {
                _logger.LogError("Ticket not updated.");
            }

            return response == BusinessLogic.Enums.StatusCode.Created
                ? (ActionResult<TicketViewModel>)Ok()
                : Conflict();
        }

        [HttpPost]
        public async Task<ActionResult<TicketViewModel>> Post(TicketViewModel ticket)
        {
            var response = await _ticketService.Create(ticket.ToModel());
            if (response != BusinessLogic.Enums.StatusCode.Created)
            {
                _logger.LogError("Ticket not created.");
            }

            return response == BusinessLogic.Enums.StatusCode.Created
                ? (ActionResult<TicketViewModel>)Ok()
                : Conflict();
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<TicketViewModel>> Delete(Guid id)
        {
            var ticket = await _ticketService.GetById(id);
            if (ticket == null)
            {
                _logger.LogInformation($"Ticket id = {id} not found.");
                return NotFound();
            }

            await _ticketService.Delete(ticket);
            return Ok(ticket);
        }
    }
}
