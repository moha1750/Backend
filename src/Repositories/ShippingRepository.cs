#pragma warning disable CS8618

using BackendTeamwork.Abstractions;
using BackendTeamwork.Databases;
using BackendTeamwork.Entities;
using Microsoft.EntityFrameworkCore;

namespace BackendTeamwork.Repositories
{
    public class ShippingRepository : IShippingRepository
    {

        private DbSet<Shipping> _shipping;
        private DatabaseContext _databaseContext;

        public ShippingRepository(DatabaseContext databaseContext)
        {
            _shipping = databaseContext.Shipping;
            _databaseContext = databaseContext;

        }

        public async Task<Shipping?> FindOneByOrderId(Guid orderId)
        {
            return await _shipping.AsNoTracking().FirstOrDefaultAsync(shipping => shipping.OrderId == orderId);
        }

        public async Task<Shipping?> FindOne(Guid shippingId)
        {
            return await _shipping.AsNoTracking().FirstOrDefaultAsync(shipping => shipping.Id == shippingId);
        }

        public async Task<Shipping> CreateOne(Shipping newShipping)
        {
            await _shipping.AddAsync(newShipping);
            await _databaseContext.SaveChangesAsync();
            return newShipping;
        }

        public async Task<Shipping> UpdateOne(Shipping updateShipping)
        {
            _shipping.Update(updateShipping);
            await _databaseContext.SaveChangesAsync();
            return updateShipping;
        }

        public async Task<Shipping> DeleteOne(Shipping deletedShipping)
        {
            _shipping.Remove(deletedShipping);
            await _databaseContext.SaveChangesAsync();
            return deletedShipping;
        }

    }
}