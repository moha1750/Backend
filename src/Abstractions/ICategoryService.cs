using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BackendTeamwork.Entities;

namespace BackendTeamwork.Abstractions
{
    public interface ICategoryService
    {

        public IEnumerable<Category> FindMany();
        public Task<Category?> FindOne(Guid id);
        public Task<Category> CreateOne(Category newCategory);

        public Task<Category?> UpdateOne(Guid categoryId, Category updateCategory);

        public Task<Category?> DeleteOne(Guid categoryId);
    }
}