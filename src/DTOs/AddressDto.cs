#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackendTeamwork.Entities
{
    public class AddressCreateDto
    {
        public string City { get; set; }
        public string? Zip { get; set; }
        public string? AddressLine { get; set; }
        public Guid UserId { get; set; }
    }
}