
using BackendTeamwork.Entities;

namespace BackendTeamwork.Abstractions
{
    public interface IProductService
    {
        public IEnumerable<Product> FindMany();

        public Product? FindOne(Guid id);

        public Product CreateOne(Product newProduct);
    }
}