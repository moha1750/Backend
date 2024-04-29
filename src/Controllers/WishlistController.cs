using System;
using System.Collections.Generic;
using BackendTeamwork.Abstractions;
using BackendTeamwork.Entities;
using Microsoft.AspNetCore.Mvc;

namespace BackendTeamwork.Controllers
{
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
    }
}
