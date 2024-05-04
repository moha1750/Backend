#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackendTeamwork.Entities
{
    public class Review
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public int Rating { get; set; }

        [StringLength(500)]
        public string? Comment { get; set; }

        [Required, ForeignKey("User")]
        public Guid UserId { get; set; }
        [Required, ForeignKey("Product")]
        public Guid ProductId { get; set; }

        public User User { get; set; }
        public Product Product { get; set; }



    }
}