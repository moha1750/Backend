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

        public Address? FindOne(Guid Id)
        {
            return _addressRepository.FindOne(Id);
        }

        public Address CreateOne(Address newAddress)
        {
            return _addressRepository.CreateOne(newAddress);
        }

        public Address? UpdateOne(Address updatedAddress)
        {
            return _addressRepository.UpdateOne(updatedAddress);
        }


    }
}