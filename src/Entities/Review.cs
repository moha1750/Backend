
namespace BackendTeamwork.Entities
{
    public class Review
    {
        public Guid Id { get; set; }
        public int Rating { get; set; }
        public string? Comment { get; set; }
        public Guid UserId { get; set; }
        public Guid ProductId { get; set; }

        public Review(Guid id, int rating, string? comment, Guid userId, Guid productId)
        {
            Id = id;
            Rating = rating;
            Comment = comment;
            UserId = userId;
            ProductId = productId;
        }
    }
}