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
    public class OrderStatusController : ControllerBase
    {
        private readonly IOrderStatusService _orderStatusService;
        private readonly ILogger<OrderStatusController> _logger;

        public OrderStatusController(
            IOrderStatusService orderStatusService,
            ILogger<OrderStatusController> logger
            )
        {
            _orderStatusService = orderStatusService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IEnumerable<OrderStatusViewModel>> Get()
        {
            return (await _orderStatusService.GetAll()).Select(ur => ur.ToViewModel());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<OrderStatusViewModel>> Get(Guid id)
        {
            var user = (await _orderStatusService.GetById(id)).ToViewModel();
            if (user == null)
            {
                _logger.LogInformation($"OrderStatus id = {id} not found.");
                return NotFound();
            }
            return new ObjectResult(user);
        }

        [HttpPut]
        public async Task<ActionResult<OrderStatusViewModel>> Update(OrderStatusViewModel orderStatus)
        {
            var response = await _orderStatusService.Update(orderStatus.ToModel());
            if (response != BusinessLogic.Enums.StatusCode.Updated)
            {
                _logger.LogError($"OrderStatus {orderStatus.Name} not found.");
            }

            return response == BusinessLogic.Enums.StatusCode.Created
                ? (ActionResult<OrderStatusViewModel>)Ok()
                : Conflict();
        }

        [HttpPost]
        public async Task<ActionResult<OrderStatusViewModel>> Post(OrderStatusViewModel orderStatus)
        {
            var response = await _orderStatusService.Create(orderStatus.ToModel());
            if (response != BusinessLogic.Enums.StatusCode.Created)
            {
                _logger.LogError($"OrderStatus {orderStatus.Name} not found.");
            }

            return response == BusinessLogic.Enums.StatusCode.Created
                ? (ActionResult<OrderStatusViewModel>)Ok()
                : Conflict();
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<OrderStatusViewModel>> Delete(Guid id)
        {
            var orderStatus = await _orderStatusService.GetById(id);
            if (orderStatus == null)
            {
                _logger.LogInformation($"OrderStatus id = {id} not found.");
                return NotFound();
            }

            await _orderStatusService.Delete(orderStatus);
            return Ok(orderStatus);
        }
    }
}
