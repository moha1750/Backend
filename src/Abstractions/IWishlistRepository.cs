using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BackendTeamwork.Entities;

namespace BackendTeamwork.Abstractions
{
    public interface IWishlistRepository
    {
        public IEnumerable<Wishlist> FindMany();
        public Task<Wishlist?> FindOne(Guid wishlistId);

        public Task<Wishlist> AddOneProduct(Wishlist wishlist, Product product);
        public Task<Wishlist> CreateOne(Wishlist newWishlist);

        public Task<Wishlist> UpdateOne(Wishlist updatedWishlist);

        public Task<Wishlist> DeleteOne(Wishlist targetWishlist);
    }
}
