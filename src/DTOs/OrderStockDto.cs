#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackendTeamwork.DTOs
{
    public class OrderStockCreateDto
    {
        public int Price { get; set; }
        public int Quantity { get; set; }
        public Guid OrderId { get; set; }
        public Guid StockId { get; set; }
    }

    public class OrderStockReduceDto
    {
        public int Quantity { get; set; }
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