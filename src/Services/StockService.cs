using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.Arm;
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

        public IEnumerable<Stock> FindMany(Guid productId)
        {
            return _stockRepository.FindMany(productId);
        }

        public async Task<Stock?> FindOne(Guid stockId)
        {
            return await _stockRepository.FindOne(stockId);
        }

        public async Task<Stock> CreateOne(Stock newStock)

        {
            return await _stockRepository.CreateOne(newStock);
        }

        public async Task<Stock?> UpdateOne(Guid stockId, Stock updatedStock)
        {
            Stock? targetStock = await _stockRepository.FindOne(stockId);
            if (targetStock is null)
            {
                return null;
            }
            return await _stockRepository.UpdateOne(updatedStock);
        }

        public async Task<Stock?> DeleteOne(Guid stockId)
        {
            Stock? stock = await _stockRepository.FindOne(stockId);
            if (stock is not null)
            {
                return await _stockRepository.DeleteOne(stock);
            }
            return null;
        }
    }
}