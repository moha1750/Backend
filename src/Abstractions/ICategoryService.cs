using BackendTeamwork.DTOs;
using BackendTeamwork.Entities;

namespace BackendTeamwork.Abstractions
{
    public interface ICategoryService
    {

        public IEnumerable<CategoryReadDto> FindMany();
        public Task<CategoryReadDto?> FindOne(Guid id);
        public Task<CategoryReadDto> CreateOne(CategoryCreateDto newCategory);

        public Task<CategoryReadDto?> UpdateOne(Guid categoryId, CategoryUpdateDto updateCategory);

        public Task<CategoryReadDto?> DeleteOne(Guid categoryId);
    }
}