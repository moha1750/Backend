
using BackendTeamwork.Abstractions;
using BackendTeamwork.Databases;
using BackendTeamwork.Entities;
using BackendTeamwork.Enums;
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

        public IEnumerable<Product> FindMany(int limit, int offset, SortBy sortBy = SortBy.Ascending)
        {
            IEnumerable<Product> sortedProducts;
            if (sortBy == SortBy.Ascending)
            {
                sortedProducts = _products.OrderBy(_products => _products.Name);
            }
            else
            {
                sortedProducts = _products.OrderByDescending(_products => _products.Name);
            }
            if (limit == 0 && offset == 0)
            {
                return sortedProducts;
            }
            return sortedProducts.Skip(offset).Take(limit);
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

        public IEnumerable<Product> Search(string searchTerm)
        {
            return _products.Where(product =>
                product.Name.ToLower().Contains(searchTerm.ToLower()) ||
                product.Description.ToLower().Contains(searchTerm.ToLower())
            );
        }

    }
}