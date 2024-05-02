using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BackendTeamwork.Abstractions;
using BackendTeamwork.Entities;
using Microsoft.AspNetCore.Mvc;

namespace BackendTeamwork.Controllers
{
    public class ReviewsController : BaseController
    {

        private IReviewService _reviewService;

        public ReviewsController(IReviewService reviewService)
        {
            _reviewService = reviewService;
        }

        // findMany
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<Review>> FindMany()
        {
            return Ok(_reviewService.FindMany());
        }

        // findOne
        [HttpGet(":reviewId")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Review?>> FindOne(Guid reviewId)
        {
            return Ok(await _reviewService.FindOne(reviewId));
        }

        // createOne
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Review>> CreateOne([FromBody] Review newReview)
        {
            Review? review = await _reviewService.CreateOne(newReview);
            if (review is not null)
            {
                return Ok(review);
            }
            return NotFound();
        }

        // updateOne
        [HttpPut(":reviewId")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Review?>> UpdateOne(Guid reviewId, [FromBody] Review updatedReview)
        {
            Review? review = await _reviewService.UpdateOne(reviewId, updatedReview);
            if (review is not null)
            {
                return Ok(review);
            }
            return NotFound();
        }


    }
}