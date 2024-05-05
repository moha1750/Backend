#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackendTeamwork.DTOs
{
    public class WishlistCreateDto
    {
        public string Name { get; set; }
        public Guid UserId { get; set; }
    }

    public class WishlistReadDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid UserId { get; set; }
    }
    public class WishlistUpdateDto
    {
        public string Name { get; set; }
        public Guid UserId { get; set; }
    }
}
