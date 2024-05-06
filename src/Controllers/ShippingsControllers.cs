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

        [HttpGet("user/:{userId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<ShippingReadDto>> FindMany([FromQuery(Name = "limit")] int limit, [FromQuery(Name = "offset")] int offset)
        {
            return Ok(_shippingService.FindMany(limit, offset));
        }

        [HttpGet(":{shippingId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<ShippingReadDto?>> FindOne(Guid shippingId)
        {
            return Ok(await _shippingService.FindOne(shippingId));
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<ShippingReadDto>> CreateOne([FromBody] ShippingCreateDto newShipping)
        {
            return Ok(await _shippingService.CreateOne(newShipping));
        }

    }
}