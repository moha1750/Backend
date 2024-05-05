#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackendTeamwork.DTOs
{
    public class OrderCreateDto
    {
        public string Status { get; set; }
        public Guid PaymentId { get; set; }
        public Guid UserId { get; set; }
    }

    public class OrderReadDto
    {
        public Guid Id { get; set; }
        public string Status { get; set; }
        public DateTime Date { get; set; }
        public Guid PaymentId { get; set; }
        public Guid UserId { get; set; }
    }

    public class OrderUpdateDto
    {
        public string Status { get; set; }
    }
}