
using BackendTeamwork.Abstractions;
using BackendTeamwork.Databases;
using BackendTeamwork.Entities;
using BackendTeamwork.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace BackendTeamwork.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private DbSet<Product> _products;
        private DatabaseContext _databaseContext;

        public ProductRepository(DatabaseContext databaseContext)
        {
            _products = databaseContext.Product;
            _databaseContext = databaseContext;

        }

        public IEnumerable<Product> FindMany()
        {
            return _products;
        }


        public async Task<Product?> FindOne(Guid productId)
        {
            return await _products.AsNoTracking().FirstOrDefaultAsync(product => product.Id == productId);
        }

        public async Task<Product> CreateOne(Product newProduct)
        {
            await _products.AddAsync(newProduct);
            await _databaseContext.SaveChangesAsync();
            return newProduct;
        }

        public async Task<Product> UpdateOne(Product updatedProduct)
        {
            _products.Update(updatedProduct);
            await _databaseContext.SaveChangesAsync();
            return updatedProduct;
        }

        public async Task<Product> DeleteOne(Product targetProduct)
        {
            _products.Remove(targetProduct);
            await _databaseContext.SaveChangesAsync();
            return targetProduct;
        }

    }
}