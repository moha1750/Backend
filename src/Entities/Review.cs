#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations.Schema;

namespace BackendTeamwork.Entities
{
    public class Review
    {
        public Guid Id { get; set; }
        public int Rating { get; set; }
        public string? Comment { get; set; }

        [ForeignKey("User")]
        public Guid UserId { get; set; }
        [ForeignKey("Product")]
        public Guid ProductId { get; set; }

        public User User { get; set; }
        public Product Product { get; set; }



    }
}