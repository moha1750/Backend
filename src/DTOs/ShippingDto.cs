#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace BackendTeamwork.DTOs
{

    public class ShippingCreateDto
    {
        [Required, StringLength(30)]
        public string TrackingNo { get; set; }
        [Required, StringLength(30)]
        public string DeliveryMethod { get; set; }
        [Required, ForeignKey("Address")]
        public Guid AddressId { get; set; }
        [Required, ForeignKey("Order")]
        public Guid OrderId { get; set; }

    }

    public class ShippingReadDto
    {

        public Guid Id { get; set; }
        public string TrackingNo { get; set; }
        public string DeliveryMethod { get; set; }
        public DateTime Date { get; set; }
        public Guid AddressId { get; set; }
        public Guid OrderId { get; set; }


    }

    public class ShippingUpdateDto
    {
        public string TrackingNo { get; set; }
        public string DeliveryMethod { get; set; }
        public DateTime Date { get; set; }
        public Guid AddressId { get; set; }
        public Guid OrderId { get; set; }
    }
}