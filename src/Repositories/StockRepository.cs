using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BackendTeamwork.Abstractions;
using BackendTeamwork.Databases;
using BackendTeamwork.Entities;
using Microsoft.EntityFrameworkCore;

namespace BackendTeamwork.Repositories
{
    public class StockRepository : IStockRepository
    {

        private DbSet<Stock> _stocks;
        private DatabaseContext _databaseContext;

        public StockRepository(DatabaseContext databaseContext)
        {
            _stocks = databaseContext.Stock;
            _databaseContext = databaseContext;

        }

        public IEnumerable<Stock> FindMany()
        {
            return _stocks;
        }

        public IEnumerable<Stock> FindMany(Guid productId)
        {
            IEnumerable<Stock> targetStocks = _stocks.Where(stock => stock.ProductId == productId);
            return targetStocks;
        }

        public async Task<Stock?> FindOne(Guid stockId)
        {
            return await _stocks.AsNoTracking().FirstOrDefaultAsync(stock => stock.Id == stockId);
        }


        public async Task<Stock> CreateOne(Stock newStock)
        {
            await _stocks.AddAsync(newStock);
            await _databaseContext.SaveChangesAsync();
            return newStock;
        }


        public async Task<Stock> UpdateOne(Stock updatedStock)
        {
            Console.WriteLine($"{updatedStock}");

            _stocks.Update(updatedStock);
            await _databaseContext.SaveChangesAsync();
            return updatedStock;
        }


        public async Task<Stock> DeleteOne(Stock deleteStock)
        {
            _stocks.Remove(deleteStock);
            await _databaseContext.SaveChangesAsync();
            return deleteStock;
        }
    }
}