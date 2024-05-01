using BackendTeamwork.Abstractions;
using BackendTeamwork.Entities;
using BackendTeamwork.Repositories;

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

        public Product? FindOne(Guid productId)
        {
            Product? targetProduct = _productRepository.FindOne(productId);

            if (targetProduct is not null)
            {
                return targetProduct;
            }
            return null;
        }

        public Product CreateOne(Product newProduct)
        {

            return _productRepository.CreateOne(newProduct);
        }

        public Product? UpdateOne(Guid productId, Product updatedProduct)
        {
            Product? targetProduct = _productRepository.FindOne(productId);

            if (targetProduct is not null)
            {
                targetProduct.Name = updatedProduct.Name;
                targetProduct.Price = updatedProduct.Price;
                targetProduct.Image = updatedProduct.Image;
                targetProduct.Description = updatedProduct.Description;
                return _productRepository.UpdateOne(targetProduct);
            }
            return null;
        }

        public void DeleteOne(Guid productId)
        {
            _productRepository.DeleteOne(productId);
        }
    }
}