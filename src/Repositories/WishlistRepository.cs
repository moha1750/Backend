<<<<<<< HEAD
using BackendTeamwork.Entities;
using System;
using System.Collections.Generic;

namespace BackendTeamwork.Abstractions
{
    public interface IWishlistItemService
    {
        IEnumerable<WishlistItem> FindAllItems();
        WishlistItem FindItemById(Guid id);
        WishlistItem AddNewItem(WishlistItem newItem);
        WishlistItem UpdateItem(Guid id, WishlistItem updatedItem);
        bool DeleteItem(Guid id);
    }
}
=======
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

        public IEnumerable<Wishlist> FindMany()
        {
            return _wishlists;
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
>>>>>>> da7de1e4169592927dc0362fcd7f741974b62bbe
