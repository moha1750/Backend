#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackendTeamwork.Entities
{
    public class OrderCreateDto
    {

        public string Status { get; set; }
        public Guid PaymentId { get; set; }
        public Guid UserId { get; set; }
    }
}