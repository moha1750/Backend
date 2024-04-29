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

        [HttpGet(":{Id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public ActionResult<Address> FindOne(Guid Id)
        {
            Address? address = _AddressService.FindOne(Id);

            if (address is not null)
            {
                return address;
            }
            return NoContent();
        }

        [HttpPost]
        public Address CreateOne([FromBody] Address newAddress)
        {
            return _AddressService.CreateOne(newAddress);
        }

        [HttpPut]
        public Address? UpdateOne(Address updatedAddress)
        {
            return _AddressService.UpdateOne(updatedAddress);
        }



    }
}