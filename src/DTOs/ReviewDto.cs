#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackendTeamwork.Entities
{
    public class ReviewCreateDto
    {
        public int Rating { get; set; }
        public string? Comment { get; set; }
        public Guid UserId { get; set; }
        public Guid ProductId { get; set; }
    }
}