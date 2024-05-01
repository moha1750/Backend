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
        public IEnumerable<Review> FindMany()
        {
            return _reviewService.FindMany();
        }

        // findOne
        [HttpGet(":reviewId")]
        public async Task<Review?> FindOne(Guid reviewId)
        {
            return await _reviewService.FindOne(reviewId);
        }

        // createOne
        [HttpPost]
        public async Task<ActionResult<Review>> CreateOne([FromBody] Review newReview)
        {
            if (newReview is not null)
            {
                await _reviewService.CreateOne(newReview);
                return CreatedAtAction(nameof(CreateOne), newReview);
            }
            return BadRequest();
        }

        // updateOne
        [HttpPut(":reviewId")]
        public async Task<ActionResult<Review?>> UpdateOne([FromBody] Review updatedReview)
        {
            return await _reviewService.UpdateOne(updatedReview);
        }

    }
}