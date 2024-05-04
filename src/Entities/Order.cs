#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations.Schema;

namespace BackendTeamwork.Entities
{
    public class Order
    {

        public Guid Id { get; set; }
        public string? Status { get; set; }
        public DateTime Date { get; set; }

        [ForeignKey("Payment")]
        public Guid PaymentId { get; set; }
        [ForeignKey("User")]
        public Guid UserId { get; set; }

        public Payment Payment { get; set; }
        public User User { get; set; }
        public IEnumerable<OrderStock> OrderStocks { get; set; }

    }
}