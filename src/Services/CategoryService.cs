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

        public Category? CreateOne(Category newCategory)
        {
            return _categoryRepository.CreateOne(newCategory);
        }

        public void DeleteOne(Guid id)
        {
            _categoryRepository.DeleteOne(id);
        }

        public Category? UpdateOne(Guid id, Category updateCategory)
        {
            Category? targetCategory = _categoryRepository.FindOne(id);

            if (targetCategory is not null)
            {
                targetCategory.Name = updateCategory.Name;
                targetCategory.Description = updateCategory.Description;
                return _categoryRepository.UpdateOne(targetCategory);
            }
            return null;
        }
    }
}