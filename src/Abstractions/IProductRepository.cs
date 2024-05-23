
using BackendTeamwork.Entities;
using BackendTeamwork.Enums;

namespace BackendTeamwork.Abstractions
{
    public interface IProductRepository
    {
        public IEnumerable<Product> FindMany(int limit, int offset, SortBy sortBy, string searchTerm = "");
        public Task<Product?> FindOne(Guid productId);

        public Task<Product> CreateOne(Product newProduct);

        public Task<Product> UpdateOne(Product updatedProduct);

        public Task<Product> DeleteOne(Product targetProducts);
        public IEnumerable<Product> Search(string searchTerm);
    }
}