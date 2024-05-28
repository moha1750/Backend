#pragma warning disable CS8618

using System.ComponentModel.DataAnnotations;

namespace BackendTeamwork.Entities
{
    public class Category
    {
        [Key]
        public Guid Id { get; set; }

        [Required, StringLength(30)]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }
        [Required, StringLength(30)]
        public string Status { get; set; } = "Draft";
        [Required, StringLength(500)]
        public string Image { get; set; }


        public IEnumerable<Product> Products { get; set; }


    }

}