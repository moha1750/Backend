
using BackendTeamwork.Entities;

namespace BackendTeamwork.Abstractions
{
    public interface IProductService
    {
        public IEnumerable<Product> FindMany();

        public Product? FindOne(Guid productId);

        public Product CreateOne(Product newProduct);

        public Product? UpdateOne(Guid productId, Product updatedProduct);

        public void DeleteOne(Guid productId);
    }
}