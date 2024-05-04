#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackendTeamwork.Entities
{
    public class PaymentCreateDto
    {
        public int Amount { get; set; }
        public string Method { get; set; }
        public Guid UserId { get; set; }
    }
}