
using BackendTeamwork.Abstractions;
using BackendTeamwork.Databases;
using BackendTeamwork.Entities;

namespace BackendTeamwork.Repositories
{
    public class ProductRepository : IProductRepository
    {
        public IEnumerable<Product> FindMany()
        {
            return new DatabaseContext().products;
        }

        public Product? FindOne(Guid id)
        {
            return new DatabaseContext().products.FirstOrDefault(product => product.Id == id);
        }
    }
}