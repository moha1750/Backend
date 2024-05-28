#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackendTeamwork.Entities
{
    public class Stock
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public int Price { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required, StringLength(30)]
        public string Size { get; set; }

        [Required, StringLength(30)]
        public string Color { get; set; }
        public string Status { get; set; } = "Card";


        [Required, ForeignKey("Product")]
        public Guid ProductId { get; set; }

        public IEnumerable<OrderStock> OrderStocks { get; set; }
        public Product Product { get; set; }

    }
}