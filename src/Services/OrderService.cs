using BackendTeamwork.Abstractions;
using BackendTeamwork.Entities;
using BackendTeamwork.Repositories;

namespace BackendTeamwork.Services
{
    public class OrderService : IOrderService
    {

        private IOrderRepository _orderRepository;

        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public IEnumerable<Order> FindMany(Guid userId)
        {
            return _orderRepository.FindMany(userId);
        }

        public Order? FindOne(Guid id)
        {
            return _orderRepository.FindOne(id);
        }

        public Order CreateOne(Order newOrder)
        {
            return _orderRepository.CreateOne(newOrder);
        }

    }
}