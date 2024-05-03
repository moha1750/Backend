using System.ComponentModel.DataAnnotations;

namespace BackendTeamwork.Entities
{
    public class User
    {
        public Guid Id { get; set; }
        [Required]
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? Phone { get; set; }
        public string? Role { get; set; }
        public Guid AddressId { get; set; }
        public Address Address { get; set; }
        [Required]

        public Guid Wishlist { get; set; }
        public IEnumerable<Payment> Payments { get; set; }
        public IEnumerable<Review> Reviews { get; set; }
        public IEnumerable<Order> Orders { get; set; }


    }
}