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
    public class WishlistRepository:IWishlistRepository
    {
        
        private DbSet<Wishlist> _wishlist;
        private DatabaseContext _databaseContext;

        public WishlistRepository(DatabaseContext databaseContext)
        {
            _wishlist = databaseContext.Wishlists;
            _databaseContext = databaseContext;

        }

        public IEnumerable<Wishlist> FindMany()
        {
            return _wishlist;
        }


        public async Task<Wishlist?> FindOne(Guid wishlistId)
        {
            return await _wishlist.AsNoTracking().FirstOrDefaultAsync(wishlist => wishlist.Id == wishlistId);
        }

        public async Task<Wishlist> CreateOne(Wishlist newWishlist)
        {
            await _wishlist.AddAsync(newWishlist);
            await _databaseContext.SaveChangesAsync();
            return newWishlist;
        }

        public async Task<Wishlist> UpdateOne(Wishlist updatedWishlist)
        {
            _wishlist.Update(updatedWishlist);
            await _databaseContext.SaveChangesAsync();
            return updatedWishlist;
        }

        public async Task<Wishlist> DeleteOne(Wishlist targetWishlist)
        {
            _wishlist.Remove(targetWishlist);
            await _databaseContext.SaveChangesAsync();
            return targetWishlist;
        }
    }
}