using System.ComponentModel.DataAnnotations;

namespace BackendTeamwork.Entities
{
    public class Order
    {

        public Guid Id { get; set; }
        [Required]
        public string? Status { get; set; }
        public DateTime Date { get; set; }
        public Guid PaymentId { get; set; }
        [Required]
        public Guid UserId { get; set; }
        [Required]
        public IEnumerable<OrderStock> OrderStocks { get; set; }

    }
}