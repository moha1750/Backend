using BackendTeamwork.Entities;

namespace BackendTeamwork.Abstractions
{
    public interface IOrderStockRepository
    {
        public IEnumerable<OrderStock> FindMany(Guid orderId);
        public Task<OrderStock> CreateOne(OrderStock newOrderStock);
        public Task<IEnumerable<OrderStock>> CreateMany(IEnumerable<OrderStock> newOrderStocks);
        // public void DeleteMany(Guid stockId);
        // public void DeleteOne(Guid id);
    }
}