
using BackendTeamwork.Entities;

namespace BackendTeamwork.Abstractions
{
    public interface IProductService
    {
        public IEnumerable<Product> FindMany();

        public Task<Product?> FindOne(Guid productId);

        public Task<Product> CreateOne(Product newProduct);

        public Task<Product?> UpdateOne(Guid productId, Product updatedProduct);

        public void DeleteOne(Guid productId);
    }
}