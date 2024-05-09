#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackendTeamwork.DTOs
{
    public class ReviewCreateDto
    {
        [Required]
        public int Rating { get; set; }
        [StringLength(500)]
        public string? Comment { get; set; }
        [Required, ForeignKey("User")]
        public Guid UserId { get; set; }
        [Required, ForeignKey("Product")]
        public Guid ProductId { get; set; }
    }

    public class ReviewReadDto
    {
        public Guid Id { get; set; }
        public int Rating { get; set; }
        public string? Comment { get; set; }
        public Guid UserId { get; set; }
        public Guid ProductId { get; set; }
    }

    public class ReviewUpdateDto
    {
        public int Rating { get; set; }
        public string? Comment { get; set; }


        public Guid UserId { get; set; }
        public Guid ProductId { get; set; }
    }
}