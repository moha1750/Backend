using BackendTeamwork.Entities;
using BackendTeamwork.Enums;

namespace BackendTeamwork.Abstractions
{
    public interface IOrderRepository
    {
        public IEnumerable<Order> FindMany(Guid userId, SortBy sortBy = SortBy.Ascending);
        public Task<Order?> FindOne(Guid id);
        public Task<Order> CreateOne(Order newOrder);

    }
}