#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackendTeamwork.DTOs
{
    public class PaymentCreateDto
    {
        [Required]
        public int Amount { get; set; }
        [Required, StringLength(30)]
        public string Method { get; set; }
        [Required, ForeignKey("User")]
        public Guid UserId { get; set; }

        public IEnumerable<OrderStockReduceDto> Items { get; set; }
    }

    public class PaymentReadDto
    {
        public Guid Id { get; set; }
        public int Amount { get; set; }
        public string Method { get; set; }
        public DateTime Date { get; set; }
        public Guid UserId { get; set; }
    }
}