using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BackendTeamwork.Abstractions;
using BackendTeamwork.Entities;

namespace BackendTeamwork.Services
{
    public class ReviewService : IReviewService
    {
        private IReviewRepository _reviewRepository;

        public ReviewService(IReviewRepository reviewRepository)
        {
            _reviewRepository = reviewRepository;
        }

        public IEnumerable<Review> FindMany()
        {
            return _reviewRepository.FindMany();
        }
        public async Task<Review?> FindOne(Guid reviewId)
        {
            Review? targetReview = await _reviewRepository.FindOne(reviewId);

            if (targetReview is not null)
            {
                return targetReview;
            }
            return null;
        }
        public async Task<Review> CreateOne(Review newReview)
        {
            return await _reviewRepository.CreateOne(newReview);
        }
        public async Task<Review?> UpdateOne(Review updatedReview)
        {
            Review? targetReview = await _reviewRepository.FindOne(updatedReview.Id);

            if (targetReview is not null)
            {
                targetReview.Rating = updatedReview.Rating;
                targetReview.Comment = updatedReview.Comment;
                return await _reviewRepository.UpdateOne(targetReview);
            }
            return null;
        }

    }
}