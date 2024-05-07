using BackendTeamwork.Abstractions;
using BackendTeamwork.DTOs;
using BackendTeamwork.Entities;
using Microsoft.AspNetCore.Authorization;
using BackendTeamwork.Enums;
using Microsoft.AspNetCore.Mvc;

namespace BackendTeamwork.Controllers
{
    public class OrdersController : BaseController
    {

        private IOrderService _orderService;

        public OrdersController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet("user/:{userId}")]
        [Authorize(Roles = "Admin, Customer")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<OrderReadDto>> FindMany(Guid userId, [FromQuery(Name = "sort")] SortBy sortBy)
        {
            return Ok(_orderService.FindMany(userId, sortBy));
        }

        [HttpGet(":{orderId}")]
        [Authorize(Roles = "Admin, Customer")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<OrderReadDto?>> FindOne(Guid orderId)
        {
            return Ok(await _orderService.FindOne(orderId));
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<OrderReadDto>> CreateOne([FromBody] OrderCreateDto newOrder)
        {
            return Ok(await _orderService.CreateOne(newOrder));
        }

    }
}