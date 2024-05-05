using BackendTeamwork.Abstractions;
using BackendTeamwork.DTOs;
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
        public async Task<ActionResult<ReviewReadDto?>> FindOne(Guid reviewId)
        {
            return Ok(await _reviewService.FindOne(reviewId));
        }

        // createOne
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ReviewReadDto>> CreateOne([FromBody] ReviewCreateDto newReview)
        {
            ReviewReadDto? review = await _reviewService.CreateOne(newReview);
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
        public async Task<ActionResult<ReviewReadDto?>> UpdateOne(Guid reviewId, [FromBody] ReviewUpdateDto updatedReview)
        {
            ReviewReadDto? review = await _reviewService.UpdateOne(reviewId, updatedReview);
            if (review is not null)
            {
                return Ok(review);
            }
            return NotFound();
        }


    }
}