<<<<<<< HEAD
using System;
using System.Collections.Generic;
using BackendTeamwork.Abstractions;
using BackendTeamwork.Entities;
=======
using BackendTeamwork.Abstractions;
using BackendTeamwork.DTOs;
>>>>>>> da7de1e4169592927dc0362fcd7f741974b62bbe
using Microsoft.AspNetCore.Mvc;

namespace BackendTeamwork.Controllers
{
<<<<<<< HEAD
    public class WishlistItemController : BaseController
    {
        private readonly WishlistItemService _wishlistItemService;

        public WishlistItemController(WishlistItemService wishlistItemService)
        {
            _wishlistItemService = wishlistItemService;
        }

        [HttpGet]
        public IEnumerable<WishlistItem> FindMany()
        {
            return _wishlistItemService.FindMany();
        }

        [HttpGet("{id}")]
        public ActionResult<WishlistItem> FindOne(Guid id)
        {
            var wishlistItem = _wishlistItemService.FindOne(id);
            if (wishlistItem != null)
                return Ok(wishlistItem);
            else
                return NotFound();
        }

        [HttpPost]
        public ActionResult<WishlistItem> CreateOne([FromBody] WishlistItem newWishlistItem)
        {
            if (newWishlistItem != null)
            {
                var createdWishlistItem = _wishlistItemService.CreateOne(newWishlistItem);
                return CreatedAtAction(nameof(CreateOne), createdWishlistItem);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPut("{id}")]
        public ActionResult<WishlistItem> UpdateOne(Guid id, [FromBody] WishlistItem updatedWishlistItem)
        {
            var result = _wishlistItemService.UpdateOne(id, updatedWishlistItem);
            if (result != null)
                return Ok(result);
            else
                return NotFound();
        }

        [HttpDelete("{id}")]
        public ActionResult<bool> DeleteOne(Guid id)
        {
            var success = _wishlistItemService.DeleteOne(id);
            if (success)
                return Ok(success);
            else
                return NotFound();
        }
=======
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

>>>>>>> da7de1e4169592927dc0362fcd7f741974b62bbe
    }
}
