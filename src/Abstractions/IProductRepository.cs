
using BackendTeamwork.Entities;

namespace BackendTeamwork.Abstractions
{
    public interface IProductRepository
    {
        public IEnumerable<Product> FindMany(int limit, int offset);
        public Task<Product?> FindOne(Guid productId);

        public Task<Product> CreateOne(Product newProduct);

        public Task<Product> UpdateOne(Product updatedProduct);

        public Task<Product> DeleteOne(Product targetProducts);
         IEnumerable<Product> Search(string searchTerm);
    }
}