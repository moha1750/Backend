using BackendTeamwork.Abstractions;
using BackendTeamwork.Entities;
using Microsoft.AspNetCore.Mvc;

namespace BackendTeamwork.Controllers
{
    public class AddressesController : BaseController
    {
        private IAddressService _AddressService;
        public AddressesController(IAddressService AddressService)
        {
            _AddressService = AddressService;
        }

        [HttpGet(":{addressId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Address>> FindOne(Guid addressId)
        {
            Address? address = await _AddressService.FindOne(addressId);
            if (address is not null)
            {
                return Ok(address);
            }
            return NotFound();
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<Address> CreateOne([FromBody] Address newAddress)
        {
            return Ok(_AddressService.CreateOne(newAddress));
        }

        [HttpPut(":{addressId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Address>> UpdateOne(Guid addressId, Address updatedAddress)
        {
            Address? updated = await _AddressService.UpdateOne(addressId, updatedAddress);
            if (updated is not null)
            {
                return Ok(updated);
            }
            return NotFound();
        }
    }
}