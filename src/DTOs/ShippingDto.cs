using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace BackendTeamwork.DTOs
{

    public class ShippingCreateDto
    {
        [Key]
        public Guid Id { get; set; }

        [Required, StringLength(30)]
        public string? Status { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required, ForeignKey("Address")]
        public Guid AddressId { get; set; }

        [Required, ForeignKey("Order")]
        public Guid OrderId { get; set; }


    }

    public class ShippingReadDto
    {

        [Key]
        public Guid Id { get; set; }

        [Required, StringLength(30)]
        public string? Status { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required, ForeignKey("Address")]
        public Guid AddressId { get; set; }

        [Required, ForeignKey("Order")]
        public Guid OrderId { get; set; }


    }

    public class ShippingUpdateDto
    {
        [Key]
        public Guid Id { get; set; }

        [Required, StringLength(30)]
        public string? Status { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required, ForeignKey("Address")]
        public Guid AddressId { get; set; }

        [Required, ForeignKey("Order")]
        public Guid OrderId { get; set; }


    }
}