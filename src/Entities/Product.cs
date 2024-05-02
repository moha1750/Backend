
using System.ComponentModel.DataAnnotations;

namespace BackendTeamwork.Entities
{
    public class Product
    {
        public Guid Id { get; set; }
        [Required]

        public string? Name { get; set; }

        public int Price { get; set; }

        public string? Image { get; set; }

        public string? Description { get; set; }

        public Guid CategoryId { get; set; }
        public IEnumerable<Review> Reviews { get; set; }
        public IEnumerable<Stock> Stocks { get; set; }


    }
}