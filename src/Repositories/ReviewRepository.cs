
using BackendTeamwork.Abstractions;
using BackendTeamwork.Databases;
using BackendTeamwork.Entities;

namespace BackendTeamwork.Repositories
{
    public class ReviewRepository : IReviewRepository
    {
        private IEnumerable<Review> _reviews;
        private DatabaseContext _databaseContext;

        public ReviewRepository(DatabaseContext databaseContext)
        {
            _reviews = databaseContext.Reviews;
            _databaseContext = databaseContext;

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