using BackendTeamwork.Entities;

namespace BackendTeamwork.Abstractions
{
    public interface IReviewService
    {
        public IEnumerable<Review> FindMany();

        public Review? FindOne(Guid id);

        public Review CreateOne(Review newReview);

        public Review? UpdateOne(Review updatedReview);
    }
}