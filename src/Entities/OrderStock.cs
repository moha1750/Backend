using System.ComponentModel.DataAnnotations;

namespace BackendTeamwork.Entities
{
    public class OrderStock
    {


        public Guid Id { get; set; }
        [Required]
        public Guid OrderId { get; set; }
        public Order Order { get; set; }
        public int Quantity { get; set; }
        public Guid StockId { get; set; }
    }
}