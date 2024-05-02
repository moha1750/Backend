using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BackendTeamwork.Abstractions;
using BackendTeamwork.Entities;

namespace BackendTeamwork.Services
{
    public class CategoryService : ICategoryService
    {
        private ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public IEnumerable<Category> FindMany()
        {
            return _categoryRepository.FindMany();
        }
        public async Task<Category?> FindOne(Guid categoryId)
        {
            return await _categoryRepository.FindOne(categoryId);
        }
        public async Task<Category> CreateOne(Category newCategory)
        {
            return await _categoryRepository.CreateOne(newCategory);
        }


        public async Task<Category?> UpdateOne(Guid categoryId, Category updateCategory)
        {
            Category? targetCategory = await _categoryRepository.FindOne(categoryId);

            if (targetCategory is not null)
            {
                return await _categoryRepository.UpdateOne(updateCategory);
            }
            return null;
        }

        public async Task<Category?> DeleteOne(Guid categoryId)
        {
            Category? targetCategory = await _categoryRepository.FindOne(categoryId);
            if (targetCategory is not null)
            {
                return await _categoryRepository.DeleteOne(targetCategory);
            }
            return null;
        }
    }
}