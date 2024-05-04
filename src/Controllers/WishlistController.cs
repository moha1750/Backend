using BackendTeamwork.Abstractions;
using BackendTeamwork.Entities;
using BackendTeamwork.Services;
using Microsoft.AspNetCore.Mvc;

namespace BackendTeamwork.Controllers
{
    public class WishlistController : BaseController
    {

        private IWishlistService _wishlistService;

        public WishlistController(IWishlistService wishlisttService)
        {
            _wishlistService = wishlisttService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<Wishlist>> FindMany()
        {
            return Ok(_wishlistService.FindMany());
        }

        [HttpGet(":wishlistId")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<Wishlist>> FindOne(Guid productId)
        {
            Wishlist? targetWishlist = await _wishlistService.FindOne(productId);
            if (targetWishlist is not null)
            {
                return Ok(targetWishlist);
            }
            return NotFound();
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Wishlist> CreateOne([FromBody] Wishlist newWishlist)
        {
            if (newWishlist is not null)
            {
                _wishlistService.CreateOne(newWishlist);
                return CreatedAtAction(nameof(CreateOne), newWishlist);
            }
            return BadRequest();
        }

        [HttpPut(":WishlistId")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Wishlist?>> UpdateOne([FromQuery] Guid WishlistId, [FromBody] Wishlist updatedWishlist)
        {
            Wishlist? targetWishlist = await _wishlistService.UpdateOne(WishlistId, updatedWishlist);
            if (targetWishlist is not null)
            {
                return Ok(updatedWishlist);
            }
            return NotFound();
        }


        [HttpDelete(":wishlistId")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Wishlist>> DeleteOne(Guid wishlistId)
        {
            Wishlist? deletedWishlist = await _wishlistService.DeleteOne(wishlistId);
            if (deletedWishlist is not null)
            {
                return Ok(deletedWishlist);
            }
            return NotFound();
        }

    }
}
