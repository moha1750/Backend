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

        public Product? FindOne(Guid id)
        {
            Product? targetProduct = _productRepository.FindOne(id);

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

        public Product? UpdateOne(Guid id, Product updatedProduct)
        {
            Product? targetProduct = _productRepository.FindOne(id);

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

        public bool DeleteOne(Guid id)
        {
            IEnumerable<Product> updatedCollection = _productRepository.FindMany();

            Product? targetProduct = _productRepository.FindOne(id);
            if (targetProduct is not null)
            {
                updatedCollection = updatedCollection.Where(product => product.Id != id);
                return _productRepository.DeleteOne(updatedCollection);
            }
            return false;
        }

    }
}