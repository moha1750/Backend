using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BackendTeamwork.Abstractions;
using BackendTeamwork.Entities;
using BackendTeamwork.Repositories;

namespace BackendTeamwork.Services
{
    public class StockService : IStockService
    {

        private IStockRepository _stockRepository;

        public StockService(IStockRepository stockRepository)
        {
            _stockRepository = stockRepository;
        }

        public IEnumerable<Stock> FindMany()
        {
            return _stockRepository.FindMany();
        }


        public Stock CreateOne(Stock newStock)
        {
            return _stockRepository.CreateOne(newStock);
        }


        public Stock? UpdateOne(Guid id, Stock updateStock)
        {
            Stock? targetStock = _stockRepository.FindOne(id);
            if (targetStock is not null)
            {
                targetStock.Quantity = updateStock.Quantity;
                targetStock.Size = updateStock.Size;
                targetStock.Color = updateStock.Color;

                return _stockRepository.UpdateOne(targetStock);
            }
            return null;
        }

        public void DeleteOne(Guid id)
        {
            _stockRepository.DeleteOne(id);

        }
    }
}