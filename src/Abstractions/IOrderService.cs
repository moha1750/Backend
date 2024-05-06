using BackendTeamwork.DTOs;
using BackendTeamwork.Entities;
using BackendTeamwork.Enums;

namespace BackendTeamwork.Abstractions
{
    public interface IOrderService
    {
        public IEnumerable<OrderReadDto> FindMany(Guid userId, SortBy sortBy);
        public Task<OrderReadDto?> FindOne(Guid orderId);
        public Task<OrderReadDto> CreateOne(OrderCreateDto newOrder);
    }
}