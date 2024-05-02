using BackendTeamwork.Abstractions;
using BackendTeamwork.Entities;
using BackendTeamwork.Repositories;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace BackendTeamwork.Services
{
    public class ProductService : IProductService
    {

        private IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }


        public IEnumerable<Product> FindMany()
        {
            return _productRepository.FindMany();
        }

        public async Task<Product?> FindOne(Guid productId)
        {
            return await _productRepository.FindOne(productId);
        }

        public async Task<Product> CreateOne(Product newProduct)
        {
            return await _productRepository.CreateOne(newProduct);
        }

        public async Task<Product?> UpdateOne(Guid productId, Product updatedProduct)
        {
            Product? oldProduct = await _productRepository.FindOne(productId);
            if (oldProduct is null)
            {
                return null;
            }
            return await _productRepository.UpdateOne(updatedProduct);
        }

        public async Task<Product?> DeleteOne(Guid productId)
        {
            Product? targetProduct = await _productRepository.FindOne(productId);
            if (targetProduct is not null)
            {
                return await _productRepository.DeleteOne(targetProduct);
            }
            return null;
        }
    }
}