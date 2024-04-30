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
        public Review? FindOne(Guid id)
        {
            return _reviewService.FindOne(id);
        }

        // createOne
        [HttpPost]
        public ActionResult<Review> CreateOne([FromBody] Review newReview)
        {
            if (newReview is not null)
            {
                _reviewService.CreateOne(newReview);
                return CreatedAtAction(nameof(CreateOne), newReview);
            }
            return BadRequest();
        }

        // updateOne
        [HttpPut(":reviewId")]
        public ActionResult<Review?> UpdateOne([FromBody] Review updatedReview)
        {
            return _reviewService.UpdateOne(updatedReview);
        }

    }
}