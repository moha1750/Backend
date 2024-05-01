using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BackendTeamwork.Abstractions;
using BackendTeamwork.Databases;
using BackendTeamwork.Entities;

namespace BackendTeamwork.Repositories
{
    public class StockRepository : IStockRepository
    {

        private IEnumerable<Stock> _stocks;

        public StockRepository()
        {
            _stocks = new DatabaseContext().Stocks;
        }


        public IEnumerable<Stock> FindMany()
        {
            return _stocks;
        }

        public Stock? FindOne(Guid stockId)
        {
            var targetStock = _stocks.FirstOrDefault(stock => stock.Id == stockId);
            if (targetStock is not null)
            {
                return targetStock;
            }
            return null;
        }


        public Stock CreateOne(Stock newStock)
        {
            Stock? createdStock = FindOne(newStock.Id);
            if (createdStock is null)
            {
                _stocks = _stocks.Append(newStock);
                return newStock;
            }
            return null!;
        }


        public Stock UpdateOne(Stock updatedStock)
        {
            var updatedCollection = _stocks.Select(stock =>
            {
                if (stock.Id == updatedStock.Id)
                {
                    return updatedStock;
                }
                return null;
            });
            _stocks = updatedCollection!;
            return updatedStock;
        }

        /* public Product UpdateOne(Product updatedProduct)
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
        }*/


        public void DeleteOne(Guid stockId)
        {
            _stocks = _stocks.Where(stock => stock.Id != stockId);
        }

    }
}