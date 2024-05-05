using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace BackendTeamwork.Entities
{
    public class Shipping
    {
        [Key]
        public Guid Id { get; set; }

        [Required, StringLength(30)]
        public string Status { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required, ForeignKey("Address")]
        public Guid AddressId { get; set; }

        [Required, ForeignKey("Order")]
        public Guid OrderId { get; set; }

        [Required, ForeignKey("User")]
        public Guid UserId { get; set; }


        public Address Address { get; set; }
        public Order Order { get; set; }
        public User User { get; set; }


    }
}