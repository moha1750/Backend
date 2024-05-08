#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using BackendTeamwork.Enums;
using Microsoft.EntityFrameworkCore;

namespace BackendTeamwork.Entities
{
    [Index(nameof(Email), IsUnique = true)]
    public class User
    {
        [Key]
        public Guid Id { get; set; }

        [Required(AllowEmptyStrings = false), StringLength(30)]
        public string FirstName { get; set; }

        [Required, StringLength(30)]
        public string LastName { get; set; }

        [Required, StringLength(100)]
        public string Email { get; set; }

        [Required, StringLength(100)]
        public string Password { get; set; }

        [StringLength(15)]
        public string? Phone { get; set; }

        [Required]
        public Role Role { get; set; } = Role.Customer;

        // [ForeignKey("Address")]
        // public Guid? AddressId { get; set; }
        // [ForeignKey("Wishlist")]
        // public Guid? WishlistId { get; set; }


        public Address Address { get; set; }
        public IEnumerable<Wishlist> Wishlists { get; set; }
        public IEnumerable<Payment> Payments { get; set; }
        public IEnumerable<Order> Orders { get; set; }
        public IEnumerable<Review> Reviews { get; set; }


    }
}