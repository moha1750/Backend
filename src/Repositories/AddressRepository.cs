using BackendTeamwork.Abstractions;
using BackendTeamwork.Databases;
using BackendTeamwork.Entities;

namespace BackendTeamwork.Repositories
{
    public class AddressRepository : IAddressRepository
    {
        private IEnumerable<Address> _addresses;

        public AddressRepository()
        {
            _addresses = new DatabaseContext().Addresses;
        }

        public Address? FindOne(Guid Id)
        {
            return _addresses.FirstOrDefault(address => address.Id == Id);
        }

        public Address CreateOne(Address newAddress)
        {
            _addresses = _addresses.Append(newAddress);

            _addresses.ToList().ForEach(address =>
            {
                Console.WriteLine($"{address.Id}");
            });

            return newAddress;
        }

        public Address? UpdateOne(Address updatedAddress)
        {
            Address? oldAddress = this.FindOne(updatedAddress.Id);
            if (oldAddress is null)
            {
                return null;
            }
            oldAddress = updatedAddress;
            return oldAddress;
        }


    }
}