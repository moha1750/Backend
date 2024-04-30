using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BackendTeamwork.Abstractions;
using BackendTeamwork.Databases;
using BackendTeamwork.Entities;

namespace BackendTeamwork.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {

        private IEnumerable<Category> _categories;

        public CategoryRepository()
        {
            _categories = new DatabaseContext().Categories;
        }


        public Category? FindOne(Guid id)
        {
            return _categories.FirstOrDefault(category => category.Id == id);
        }

        public Category? CreateOne(Category newCategory)
        {
            Category? checkCategory = _categories.FirstOrDefault(category => category.Id == newCategory.Id);
            if (checkCategory is null)
            {
                _categories = _categories.Append(newCategory);
                return newCategory;
            }
            return null;
        }

        public Category UpdateOne(Category updateCategory)
        {
            var updatedCollection = _categories.Select(category =>
            {
                if (category.Id == updateCategory.Id)
                {
                    return updateCategory;
                }
                return null;
            });
            _categories = updatedCollection!;
            return updateCategory;
        }

        public void DeleteOne(Guid categoryId)
        {
            _categories = _categories.Where(category => category.Id != categoryId);
        }

    }
}