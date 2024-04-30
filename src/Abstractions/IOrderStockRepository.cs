using BackendTeamwork.Entities;

namespace BackendTeamwork.Abstractions
{
    public interface IOrderStockRepository
    {
        public IEnumerable<OrderStock> FindMany(Guid orderId);
        public OrderStock CreateOne(OrderStock newOrderStock);
        // public void DeleteMany(Guid stockId);
        // public void DeleteOne(Guid id);
    }
}