using BackendTeamwork.Entities;

namespace BackendTeamwork.Abstractions
{
    public interface IOrderRepository
    {
        public IEnumerable<Order> FindMany(Guid userId);
        public Task<Order?> FindOne(Guid id);
        public Task<Order> CreateOne(Order newOrder);

    }
}