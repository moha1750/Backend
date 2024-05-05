
using BackendTeamwork.Entities;

namespace BackendTeamwork.Abstractions
{
    public interface IProductRepository
    {
        public IEnumerable<Product> FindMany();
        public Task<Product?> FindOne(Guid productId);

        public Task<Product> CreateOne(Product newProduct);

        public Task<Product> UpdateOne(Product updatedProduct);

        public Task<Product> DeleteOne(Product targetProducts);
    }
}