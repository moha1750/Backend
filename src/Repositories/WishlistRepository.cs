using BackendTeamwork.Abstractions;
using BackendTeamwork.Databases;
using BackendTeamwork.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations.Operations;

namespace BackendTeamwork.Repositories
{
    public class WishlistRepository : IWishlistRepository
    {

        private DbSet<Wishlist> _wishlists;
        private DatabaseContext _databaseContext;

        public WishlistRepository(DatabaseContext databaseContext)
        {
            _wishlists = databaseContext.Wishlist;
            _databaseContext = databaseContext;

        }

        public IEnumerable<Wishlist> FindMany(int limit, int offset)
        {
            if (limit == 0 && offset == 0)
            {
                return _wishlists;
            }
            return _wishlists.Skip(offset).Take(limit);
        }


        public async Task<Wishlist?> FindOne(Guid wishlistId)
        {
            return await _wishlists.AsNoTracking().FirstOrDefaultAsync(wishlist => wishlist.Id == wishlistId);
        }

        public async Task<Wishlist> AddOneProduct(Wishlist wishlist, Product product)
        {
            if (wishlist.Products == null)
            {
                wishlist.Products = new List<Product>();
            }
            ((List<Product>)wishlist.Products).Add(product);
            _databaseContext.Update(wishlist);
            await _databaseContext.SaveChangesAsync();
            return wishlist;
        }

        public async Task<Wishlist> CreateOne(Wishlist newWishlist)
        {
            await _wishlists.AddAsync(newWishlist);
            await _databaseContext.SaveChangesAsync();
            return newWishlist;
        }

        public async Task<Wishlist> UpdateOne(Wishlist updatedWishlist)
        {
            _wishlists.Update(updatedWishlist);
            await _databaseContext.SaveChangesAsync();
            return updatedWishlist;
        }

        public async Task<Wishlist> DeleteOne(Wishlist targetWishlist)
        {
            _wishlists.Remove(targetWishlist);
            await _databaseContext.SaveChangesAsync();
            return targetWishlist;
        }
    }
}
