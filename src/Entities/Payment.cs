#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations.Schema;

namespace BackendTeamwork.Entities
{
    public class Payment
    {

        public Guid Id { get; set; }
        public int Amount { get; set; }
        public string? Method { get; set; }
        public DateTime Date { get; set; }

        [ForeignKey("User")]
        public Guid UserId { get; set; }


        public User User { get; set; }
        public Order Order { get; set; }

    }
}