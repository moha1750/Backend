using System.ComponentModel.DataAnnotations;

namespace BackendTeamwork.Entities
{
    public class Category
    {
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public IEnumerable<Product> Products { get; set; }


    }
}