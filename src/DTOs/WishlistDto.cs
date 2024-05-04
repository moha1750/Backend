#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackendTeamwork.Entities
{
    public class WishlistCreateDto
    {
        public string Name { get; set; }
        public Guid UserId { get; set; }
    }
}
