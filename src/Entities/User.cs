#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackendTeamwork.Entities
{
    public class User
    {
        public Guid Id { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        public string Password { get; set; }
        public string? Phone { get; set; }
        public string Role { get; set; }

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