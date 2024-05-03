using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BackendTeamwork.Entities;

namespace BackendTeamwork.Abstractions
{
    public interface IWishlistService
    {
                public IEnumerable<Wishlist> FindMany();

        public Task<Wishlist?> FindOne(Guid wishlistId);

        public Task<Wishlist> CreateOne(Wishlist newProduct);

        public Task<Wishlist?> UpdateOne(Guid wishlistId, Wishlist updatedWishlist);

        public Task<Wishlist?> DeleteOne(Guid wishlistId);
    }
}