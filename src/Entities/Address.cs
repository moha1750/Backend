#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations.Schema;

namespace BackendTeamwork.Entities
{
    public class Address
    {
        public Guid Id { get; set; }
        public string City { get; set; }
        public string Zip { get; set; }
        public string AddressLine { get; set; }

        [ForeignKey("User")]
        public Guid UserId { get; set; }

        public User User { get; set; }

    }
}