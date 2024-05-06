#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackendTeamwork.Entities
{
    public class Order
    {

        [Key]
        public Guid Id { get; set; }

        [Required, StringLength(30)]
        public string Status { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required, ForeignKey("Payment")]
        public Guid PaymentId { get; set; }

        [Required, ForeignKey("User")]
        public Guid UserId { get; set; }


        public Payment Payment { get; set; }
        public Shipping Shipping { get; set; }

        public User User { get; set; }
        public IEnumerable<OrderStock> OrderStocks { get; set; }

    }
}