
using BackendTeamwork.Abstractions;
using BackendTeamwork.Databases;
using BackendTeamwork.Entities;
using BackendTeamwork.Services;

namespace BackendTeamwork.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private IEnumerable<Product> _products;

        public ProductRepository()
        {
            _products = new DatabaseContext().Products;
        }

        public IEnumerable<Product> FindMany()
        {
            return _products;
        }

        public Product? FindOne(Guid id)
        {
            return _products.FirstOrDefault(product => product.Id == id);
        }

        public Product CreateOne(Product newProduct)
        {
            Product? checkProduct = FindOne(newProduct.Id);
            if (checkProduct is null)
            {
                _products = _products.Append(newProduct);
                return newProduct;
            }
            return null!;
        }

        public Product UpdateOne(Product updatedProduct)
        {
            var updatedCollection = _products.Select(product =>
            {
                if (product.Id == updatedProduct.Id)
                {
                    return updatedProduct;
                }
                return product;
            });

            _products = updatedCollection;
            return updatedProduct;
        }

        public bool DeleteOne(IEnumerable<Product> updatedCollection)
        {
            _products = updatedCollection;
            return true;
        }


    }
}