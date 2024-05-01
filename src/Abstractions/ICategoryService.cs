using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BackendTeamwork.Entities;

namespace BackendTeamwork.Abstractions
{
    public interface ICategoryService
    {

        public Category? CreateOne(Category newCategory);

        public Category? UpdateOne(Guid id, Category updateCategory);

        public void DeleteOne(Guid id);

    }
}