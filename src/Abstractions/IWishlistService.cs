using BackendTeamwork.DTOs;

namespace BackendTeamwork.Abstractions
{
    public interface IWishlistService
    {
        public IEnumerable<WishlistReadDto> FindMany();

        public Task<WishlistReadDto?> FindOne(Guid wishlistId);

        public Task<WishlistReadDto?> AddOneProduct(Guid wishlistId, Guid productId);

        public Task<WishlistReadDto> CreateOne(WishlistCreateDto newProduct);

        public Task<WishlistReadDto?> UpdateOne(Guid wishlistId, WishlistUpdateDto updatedWishlist);

        public Task<WishlistReadDto?> DeleteOne(Guid wishlistId);
    }
}