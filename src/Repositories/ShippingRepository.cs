using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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


        public IEnumerable<Shipping> FindMany(int limit, int offset)
        {
            return _shipping.Skip(offset).Take(limit).ToList();
        }

        public async Task<Shipping?> FindOne(Guid id)
        {
            return await _shipping.AsNoTracking().FirstOrDefaultAsync(shipping => shipping.Id == id);
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