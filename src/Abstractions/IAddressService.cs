using BackendTeamwork.Entities;

namespace BackendTeamwork.Abstractions
{
    public interface IAddressService
    {
        public Address? FindOne(Guid Id);
        public Address CreateOne(Address newAddress);
        public Address? UpdateOne(Address updatedAddress);
    }
}