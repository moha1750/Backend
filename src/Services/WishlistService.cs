using AutoMapper;
using BackendTeamwork.Abstractions;
using BackendTeamwork.DTOs;
using BackendTeamwork.Entities;

namespace BackendTeamwork.Services
{
    public class WishlistService : IWishlistService
    {

        private IWishlistRepository _wishlistRepository;
        private IProductRepository _productRepository;
        private IMapper _mapper;

        public WishlistService(IWishlistRepository wishlistRepository, IMapper mapper, IProductRepository productRepository)
        {
            _wishlistRepository = wishlistRepository;
            _mapper = mapper;
            _productRepository = productRepository;
        }


        public IEnumerable<WishlistReadDto> FindMany(int limit, int offset)
        {
            return _wishlistRepository.FindMany(limit, offset).Select(_mapper.Map<WishlistReadDto>);
        }

        public async Task<WishlistReadDto?> FindOne(Guid wishlistId)
        {
            return _mapper.Map<WishlistReadDto>(await _wishlistRepository.FindOne(wishlistId));
        }

        public async Task<WishlistReadDto?> AddOneProduct(Guid wishlistId, Guid productId)
        {
            Wishlist? wishlist = await _wishlistRepository.FindOne(wishlistId);
            Product? product = await _productRepository.FindOne(productId);
            if (wishlist is null || product is null)
            {
                return null;
            }
            wishlist.Id = wishlistId;
            product.Id = productId;
            return _mapper.Map<WishlistReadDto>(await _wishlistRepository.AddOneProduct(wishlist, product));
        }


        public async Task<WishlistReadDto> CreateOne(WishlistCreateDto newWishlist)
        {
            return _mapper.Map<WishlistReadDto>(await _wishlistRepository.CreateOne(_mapper.Map<Wishlist>(newWishlist)));
        }

        public async Task<WishlistReadDto?> UpdateOne(Guid wishlistId, WishlistUpdateDto updatedWishlist)
        {
            Wishlist? oldWishlist = await _wishlistRepository.FindOne(wishlistId);
            if (oldWishlist is null)
            {
                return null;
            }
            Wishlist wishlist = _mapper.Map<Wishlist>(updatedWishlist);
            wishlist.Id = wishlistId;
            return _mapper.Map<WishlistReadDto>(await _wishlistRepository.UpdateOne(wishlist));
        }

        public async Task<WishlistReadDto?> DeleteOne(Guid wishlistId)
        {
            Wishlist? targetWishlist = await _wishlistRepository.FindOne(wishlistId);
            if (targetWishlist is not null)
            {
                return _mapper.Map<WishlistReadDto>(await _wishlistRepository.DeleteOne(targetWishlist));
            }
            return null;
        }
    }
}