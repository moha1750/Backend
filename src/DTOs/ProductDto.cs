#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;

namespace BackendTeamwork.DTOs
{

    public class ProductCreateDto
    {
        [Required, StringLength(100)]
        public string Name { get; set; }
        [Required, StringLength(200)]
        public string Image { get; set; }
        [Required, StringLength(500)]
        public string Description { get; set; }
        [Required, ForeignKey("Category")]
        public Guid CategoryId { get; set; }
        [Required, StringLength(30)]
        public string Status { get; set; }

        public IEnumerable<StockCreateDtoWithoutId>? NewStocks { get; set; }
    }

    public class ProductReadDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
        public Guid CategoryId { get; set; }
        public string Status { get; set; }

    }

    public class ProductUpdateDto
    {
        public string Name { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
        public Guid CategoryId { get; set; }
        public string Status { get; set; }

    }

    public class ProductWithStock
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
        public Guid CategoryId { get; set; }
        public string Status { get; set; } = "Draft";
        public Guid? StockId { get; set; }
        public int? Price { get; set; }
        public int? Quantity { get; set; }
        public string? Size { get; set; }
        public string? Color { get; set; }

    }
}