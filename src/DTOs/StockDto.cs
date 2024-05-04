#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackendTeamwork.Entities
{
    public class StockCreateDto
    {
        public int Quantity { get; set; }
        public string Size { get; set; }
        public string Color { get; set; }
        public Guid ProductId { get; set; }

    }
}