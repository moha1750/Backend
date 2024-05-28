
using BackendTeamwork.Abstractions;
using BackendTeamwork.Databases;
using BackendTeamwork.DTOs;
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
        private DbSet<Stock> _stocks;
        private DatabaseContext _databaseContext;

        public ProductRepository(DatabaseContext databaseContext)
        {
            _products = databaseContext.Product;
            _databaseContext = databaseContext;
            _stocks = databaseContext.Stock;

        }

        public IEnumerable<ProductWithStock> FindMany(int limit, int offset, SortBy sortBy = SortBy.Ascending, string? searchTerm = null)
        {
            var products = from product in _products
                           join stock in _stocks on product.Id equals stock.ProductId into ps
                           from s in ps.DefaultIfEmpty()
                           select new ProductWithStock
                           {
                               Id = product.Id,
                               Name = product.Name,
                               Image = product.Image,
                               Description = product.Description,
                               CategoryId = product.CategoryId,
                               Status = product.Status,
                               StockId = s.Id,
                               Price = s.Price,
                               Quantity = s.Quantity,
                               Size = s.Size,
                               Color = s.Color
                           };


            if (searchTerm != null)
            {
                IEnumerable<ProductWithStock> searchedProducts = products.Where(product =>
                          product.Name.ToLower().Contains(searchTerm.ToLower()) ||
                          product.Description.ToLower().Contains(searchTerm.ToLower()));

                return searchedProducts;
            }

            IEnumerable<ProductWithStock> sortedProducts;
            if (sortBy == SortBy.Ascending)
            {
                sortedProducts = products.OrderBy(searchedProduct => searchedProduct.Name);
            }
            else
            {
                sortedProducts = products.OrderByDescending(searchedProduct => searchedProduct.Name);
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