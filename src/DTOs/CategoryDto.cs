#pragma warning disable CS8618

using System.ComponentModel.DataAnnotations;

namespace BackendTeamwork.Entities
{
    public class CategoryCreateDto
    {
        public string Name { get; set; }
        public string Description { get; set; }

    }

}