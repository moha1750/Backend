using BackendTeamwork.Entities;

namespace BackendTeamwork.Abstractions
{
    public interface IReviewService
    {
        public IEnumerable<Review> FindMany();

        public Task<Review?> FindOne(Guid id);

        public Task<Review> CreateOne(Review newReview);

        public Task<Review?> UpdateOne(Guid reviewId, Review updatedReview);
        public Task<Review> DeleteOne(Review deleteReview);

    }
}