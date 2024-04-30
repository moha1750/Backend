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
        public Review? FindOne(Guid id)
        {
            Review? targetReview = _reviewRepository.FindOne(id);

            if (targetReview is not null)
            {
                return targetReview;
            }
            return null;
        }
        public Review CreateOne(Review newReview)
        {
            return _reviewRepository.CreateOne(newReview);
        }
        public Review? UpdateOne(Review updatedReview)
        {
            Review? targetReview = _reviewRepository.FindOne(updatedReview.Id);

            if (targetReview is not null)
            {
                targetReview.Rating = updatedReview.Rating;
                targetReview.Comment = updatedReview.Comment;
                return _reviewRepository.UpdateOne(targetReview);
            }
            return null;
        }

    }
}