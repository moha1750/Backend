
namespace BackendTeamwork.Entities
{
    public class Review
    {
        public Guid Id { get; set; }
        public int Rating { get; set; }
        public string? Comment { get; set; }
        public Guid UserId { get; set; }
        public Guid ProductId { get; set; }
    }
}