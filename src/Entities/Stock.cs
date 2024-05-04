#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations.Schema;

namespace BackendTeamwork.Entities
{
    public class Stock
    {
        public Guid Id { get; set; }
        public int Quantity { get; set; }
        public string Size { get; set; }
        public string Color { get; set; }

        [ForeignKey("Product")]
        public Guid ProductId { get; set; }

        public IEnumerable<OrderStock> OrderStocks { get; set; }
        public Product Product { get; set; }

    }
}