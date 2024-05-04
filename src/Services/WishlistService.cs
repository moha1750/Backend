using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BackendTeamwork.Abstractions;
using BackendTeamwork.Entities;

namespace BackendTeamwork.Services
{
    public class WishlistService:IWishlistService
    {

        private IWishlistRepository _wishlistRepository;

        public WishlistService(IWishlistRepository wishlistRepository)
        {
            _wishlistRepository = wishlistRepository;
        }


        public IEnumerable<Wishlist> FindMany()
        {
            return _wishlistRepository.FindMany();
        }

        public async Task<Wishlist?> FindOne(Guid wishlistId)
        {
            return await _wishlistRepository.FindOne(wishlistId);
        }

        public async Task<Wishlist> CreateOne(Wishlist newWishlist)
        {
            return await _wishlistRepository.CreateOne(newWishlist);
        }

        public async Task<Wishlist?> UpdateOne(Guid wishlistId, Wishlist updatedWishlist)
        {
            Wishlist? oldWishlist = await _wishlistRepository.FindOne(wishlistId);
            if (oldWishlist is null)
            {
                return null;
            }
            return await _wishlistRepository.UpdateOne(updatedWishlist);
        }

        public async Task<Wishlist?> DeleteOne(Guid wishlistId)
        {
            Wishlist? targetWishlist = await _wishlistRepository.FindOne(wishlistId);
            if (targetWishlist is not null)
            {
                return await _wishlistRepository.DeleteOne(targetWishlist);
            }
            return null;
        }
    }
}