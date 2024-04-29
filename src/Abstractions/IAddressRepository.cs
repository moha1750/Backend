using BackendTeamwork.Entities;

namespace BackendTeamwork.Abstractions
{
    public interface IAddressRepository
    {

        public Address? FindOne(Guid Id);
        public Address CreateOne(Address newAddress);
        public Address? UpdateOne(Address updatedAddress);

    }
}