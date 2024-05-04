using AutoMapper;
using BackendTeamwork.Abstractions;
using BackendTeamwork.DTOs;
using BackendTeamwork.Entities;

namespace BackendTeamwork.Services
{
    public class CategoryService : ICategoryService
    {
        private ICategoryRepository _categoryRepository;
        private IMapper _mapper;

        public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public IEnumerable<CategoryReadDto> FindMany()
        {
            return _categoryRepository.FindMany().Select(_mapper.Map<CategoryReadDto>);
        }
        public async Task<CategoryReadDto?> FindOne(Guid categoryId)
        {
            return _mapper.Map<CategoryReadDto>(await _categoryRepository.FindOne(categoryId));
        }
        public async Task<CategoryReadDto> CreateOne(CategoryCreateDto newCategory)
        {
            return _mapper.Map<CategoryReadDto>(await _categoryRepository.CreateOne(_mapper.Map<Category>(newCategory)));
        }


        public async Task<CategoryReadDto?> UpdateOne(Guid categoryId, CategoryUpdateDto updateCategory)
        {
            Category? targetCategory = await _categoryRepository.FindOne(categoryId);

            if (targetCategory is null)
            {
                return null;
            }
            Category category = _mapper.Map<Category>(updateCategory);
            category.Id = categoryId;
            return _mapper.Map<CategoryReadDto>(await _categoryRepository.UpdateOne(category));
        }

        public async Task<CategoryReadDto?> DeleteOne(Guid categoryId)
        {
            Category? targetCategory = await _categoryRepository.FindOne(categoryId);
            if (targetCategory is not null)
            {
                return _mapper.Map<CategoryReadDto>(await _categoryRepository.DeleteOne(targetCategory));
            }
            return null;
        }
    }
}