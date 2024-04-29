
using BackendTeamwork.Abstractions;
using BackendTeamwork.Databases;
using BackendTeamwork.Entities;

namespace BackendTeamwork.Repositories
{
    public class ReviewRepository : IReviewRepository
    {
        private IEnumerable<Review> _reviews;
        public ReviewRepository()
        {
            _reviews = new DatabaseContext().Reviews;
        }

        public IEnumerable<Review> FindMany()
        {
            return _reviews;
        }
        public Review? FindOne(Guid id)
        {
            return _reviews.FirstOrDefault(review => review.Id == id);
        }
        public Review CreateOne(Review newReview)
        {
            _reviews = _reviews.Append(newReview);
            return newReview;
        }
        public Review UpdateOne(Review updatedReview)
        {
            var updatedCollection = _reviews.Select(review =>
            {
                if (review.Id == updatedReview.Id)
                {
                    return updatedReview;
                }
                return review;
            });

            _reviews = updatedCollection;
            return updatedReview;
        }

    }
}