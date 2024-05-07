using BackendTeamwork.Abstractions;
using BackendTeamwork.DTOs;
using BackendTeamwork.Entities;
using Microsoft.AspNetCore.Mvc;

namespace BackendTeamwork.Controllers
{
    public class ShippingController : BaseController
    {

        private IShippingService _shippingService;

        public ShippingController(IShippingService shippingService)
        {
            _shippingService = shippingService;
        }

        [HttpGet(":{shippingId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<ShippingReadDto?>> FindOne(Guid orderId)
        {
            return Ok(await _shippingService.FindOne(orderId));
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<ShippingReadDto>> CreateOne([FromBody] ShippingCreateDto newShipping)
        {
            return Ok(await _shippingService.CreateOne(newShipping));
        }

    }
}