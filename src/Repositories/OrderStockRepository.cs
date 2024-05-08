using System.Security.Cryptography.X509Certificates;
using BackendTeamwork.Abstractions;
using BackendTeamwork.Databases;
using BackendTeamwork.Entities;
using Microsoft.EntityFrameworkCore;

namespace BackendTeamwork.Repositories
{
    public class OrderStockRepository : IOrderStockRepository
    {
        private DbSet<OrderStock> _orderStocks;
        private DatabaseContext _databaseContext;
        public OrderStockRepository(DatabaseContext databaseContext)
        {
            _orderStocks = databaseContext.OrderStock;
            _databaseContext = databaseContext;
        }

        public IEnumerable<OrderStock> FindMany(Guid orderId)
        {
            return _orderStocks.Where(orderStock => orderStock.StockId == orderId);
        }

        public async Task<OrderStock> CreateOne(OrderStock newOrderStock)
        {
            await _orderStocks.AddAsync(newOrderStock);
            await _databaseContext.SaveChangesAsync();
            return newOrderStock;
        }

        public async Task<IEnumerable<OrderStock>> CreateMany(IEnumerable<OrderStock> newOrderStocks)
        {
            _orderStocks.AttachRange(newOrderStocks);
            await _orderStocks.AddRangeAsync(newOrderStocks);
            await _databaseContext.SaveChangesAsync();
            return newOrderStocks;
        }


    }
}