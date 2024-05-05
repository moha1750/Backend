using BackendTeamwork.Abstractions;
using BackendTeamwork.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace BackendTeamwork.Controllers
{
    public class WishlistController : BaseController
    {

        private IWishlistService _wishlistService;

        public WishlistController(IWishlistService wishlistService)
        {
            _wishlistService = wishlistService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<WishlistReadDto>> FindMany([FromQuery(Name = "limit")] int limit, [FromQuery(Name = "offset")] int offset)
        {
            return Ok(_wishlistService.FindMany(limit, offset));
        }

        [HttpGet(":{wishlistId}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<WishlistReadDto>> FindOne(Guid wishlistId)
        {
            WishlistReadDto? targetWishlist = await _wishlistService.FindOne(wishlistId);
            if (targetWishlist is not null)
            {
                return Ok(targetWishlist);
            }
            return NotFound();
        }

        [HttpPut(":{wishlistId}/:{productId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<WishlistReadDto>> AddOneProduct(Guid wishlistId, Guid productId)
        {
            WishlistReadDto? targetWishlist = await _wishlistService.AddOneProduct(wishlistId, productId);
            if (targetWishlist is not null)
            {
                return Ok(targetWishlist);
            }
            return NotFound();
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<WishlistReadDto> CreateOne([FromBody] WishlistCreateDto newWishlist)
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
        public async Task<ActionResult<WishlistReadDto?>> UpdateOne([FromQuery] Guid WishlistId, [FromBody] WishlistUpdateDto updatedWishlist)
        {
            WishlistReadDto? targetWishlist = await _wishlistService.UpdateOne(WishlistId, updatedWishlist);
            if (targetWishlist is not null)
            {
                return Ok(updatedWishlist);
            }
            return NotFound();
        }


        [HttpDelete(":wishlistId")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<WishlistReadDto>> DeleteOne(Guid wishlistId)
        {
            WishlistReadDto? deletedWishlist = await _wishlistService.DeleteOne(wishlistId);
            if (deletedWishlist is not null)
            {
                return Ok(deletedWishlist);
            }
            return NotFound();
        }

    }
}
