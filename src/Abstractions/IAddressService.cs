using BackendTeamwork.DTOs;
using BackendTeamwork.Entities;

namespace BackendTeamwork.Abstractions
{
    public interface IAddressService
    {
        public Task<AddressReadDto?> FindOne(Guid addressId);
        public Task<AddressReadDto> CreateOne(AddressCreateDto newAddress);
        public Task<AddressReadDto?> UpdateOne(Guid addressId, AddressUpdateDto updatedAddress);
    }
}