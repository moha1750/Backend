#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations.Schema;

namespace BackendTeamwork.Entities
{
    public class OrderStock
    {
        public Guid Id { get; set; }
        public int Quantity { get; set; }

        [ForeignKey("Order")]
        public Guid OrderId { get; set; }
        [ForeignKey("Stock")]
        public Guid StockId { get; set; }

        public Order Order { get; set; }
        public Stock Stock { get; set; }
    }
}