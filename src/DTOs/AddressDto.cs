#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackendTeamwork.DTOs
{
    public class AddressCreateDto
    {
        public string City { get; set; }
        public string? Zip { get; set; }
        public string? AddressLine { get; set; }
        public Guid UserId { get; set; }
    }

    public class AddressReadDto
    {
        public Guid Id { get; set; }
        public string City { get; set; }
        public string? Zip { get; set; }
        public string? AddressLine { get; set; }
        public Guid UserId { get; set; }
    }

    public class AddressUpdateDto
    {
        public string City { get; set; }
        public string? Zip { get; set; }
        public string? AddressLine { get; set; }
        public Guid UserId { get; set; }
    }
}