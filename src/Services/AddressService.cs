using BackendTeamwork.Abstractions;
using BackendTeamwork.Entities;

namespace BackendTeamwork.Services
{
    public class AddressService : IAddressService
    {
        private IAddressRepository _addressRepository;

        public AddressService(IAddressRepository addressRepository)
        {
            _addressRepository = addressRepository;
        }

        public async Task<Address?> FindOne(Guid addressId)
        {
            return await _addressRepository.FindOne(addressId);
        }

        public async Task<Address> CreateOne(Address newAddress)
        {
            return await _addressRepository.CreateOne(newAddress);
        }

        public async Task<Address?> UpdateOne(Guid addressId, Address updatedAddress)
        {
            Address? oldAddress = await _addressRepository.FindOne(addressId);
            if (oldAddress is null)
            {
                return null;
            }
            return await _addressRepository.UpdateOne(addressId, updatedAddress);
        }


    }
}