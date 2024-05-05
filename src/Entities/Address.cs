#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackendTeamwork.Entities
{
    public class Address
    {
        [Key]
        public Guid Id { get; set; }
        [Required, StringLength(30)]
        public string City { get; set; }
        [Required, StringLength(10)]
        public string? Zip { get; set; }
        [StringLength(100)]
        public string? AddressLine { get; set; }

        [Required, ForeignKey("User")]
        public Guid UserId { get; set; }

        public User User { get; set; }

    }
}