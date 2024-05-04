#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackendTeamwork.Entities
{
    public class OrderStockCreateDto
    {
        public int Quantity { get; set; }
        public Guid OrderId { get; set; }
        public Guid StockId { get; set; }
    }
}