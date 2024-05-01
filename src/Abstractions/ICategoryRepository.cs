using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BackendTeamwork.Entities;

namespace BackendTeamwork.Abstractions
{
    public interface ICategoryRepository
    {

        public Category? FindOne(Guid id);
        public Category? CreateOne(Category newCategory);

        public Category UpdateOne(Category updateCategory);

        public void DeleteOne(Guid id);

    }
}