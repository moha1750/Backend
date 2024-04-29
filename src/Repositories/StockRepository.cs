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
            //_products = new DatabaseContext().products;
            _stocks = new DatabaseContext().Stocks;
        }


        public IEnumerable<Stock> FindMany()
        {
            return _stocks;
        }

        public Stock? FindOne(Guid id)
        {
            return _stocks.FirstOrDefault(stock => stock.Id == id);
        }


        public Stock CreateOne(Stock newStock)
        {
            _stocks = _stocks.Append(newStock);
            return newStock;
        }


        public void DeleteOne(Guid id)
        {
            throw new NotImplementedException();
        }

        public Stock? UpdateOne(Stock updateStock)
        {
            throw new NotImplementedException();
        }
    }
}