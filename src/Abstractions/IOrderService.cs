using BackendTeamwork.Entities;

namespace BackendTeamwork.Abstractions
{
    public interface IOrderService
    {
        public IEnumerable<Order> FindMany(Guid userId);
        public Order? FindOne(Guid id);
        public Order CreateOne(Order newOrder);
    }
}