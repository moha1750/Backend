using BackendTeamwork.Abstractions;
using BackendTeamwork.Databases;
using BackendTeamwork.Entities;
using Microsoft.EntityFrameworkCore;

namespace BackendTeamwork.Repositories
{
    public class AddressRepository : IAddressRepository
    {

        private DbSet<Address> _addresses;
        private DatabaseContext _databaseContext;

        public AddressRepository(DatabaseContext databaseContext)
        {
            _addresses = databaseContext.Addresses;
            _databaseContext = databaseContext;

        }

        public async Task<Address?> FindOne(Guid AddressId)
        {
            return await _addresses.FirstOrDefaultAsync(address => address.Id == AddressId);
        }

        public async Task<Address> CreateOne(Address newAddress)
        {
            await _addresses.AddAsync(newAddress);
            await _databaseContext.SaveChangesAsync();
            return newAddress;
        }

        public async Task<Address> UpdateOne(Guid addressId, Address updatedAddress)
        {
            _addresses.Update(updatedAddress);
            await _databaseContext.SaveChangesAsync();
            return updatedAddress;
        }


    }
}