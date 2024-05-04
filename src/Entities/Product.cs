#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace BackendTeamwork.Entities
{
    public class Product
    {
        public Guid Id { get; set; }

        public string? Name { get; set; }

        public int Price { get; set; }

        public string? Image { get; set; }

        public string? Description { get; set; }

        [ForeignKey("Category")]
        public Guid CategoryId { get; set; }

        public Category Category { get; set; }
        public IEnumerable<Wishlist> Wishlists { get; set; }
        public IEnumerable<Review> Reviews { get; set; }
        public IEnumerable<Stock> Stocks { get; set; }


    }
}