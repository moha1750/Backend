#pragma warning disable CS8618

using System.ComponentModel.DataAnnotations;

namespace BackendTeamwork.DTOs
{
    public class CategoryCreateDto
    {
        [Required, StringLength(30)]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required, StringLength(30)]
        public string Status { get; set; }
        [Required, StringLength(200)]
        public string Image { get; set; }

    }

    public class CategoryReadDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public string Status { get; set; }

    }

    public class CategoryUpdateDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public string Status { get; set; }
    }

}