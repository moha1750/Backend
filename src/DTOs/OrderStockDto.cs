#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackendTeamwork.DTOs
{
    public class OrderStockCreateDto
    {
        [Required]
        public int Price { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required, ForeignKey("Order")]
        public Guid OrderId { get; set; }
        [Required, ForeignKey("Stock")]
        public Guid StockId { get; set; }
    }

    public class OrderStockReduceDto
    {
        [Required]
        public int Quantity { get; set; }
        [Required, ForeignKey("Stock")]
        public Guid StockId { get; set; }
    }

    public class OrderStockReadDto
    {
        public int Price { get; set; }
        public int Quantity { get; set; }
        public Guid OrderId { get; set; }
        public Guid StockId { get; set; }
    }
}