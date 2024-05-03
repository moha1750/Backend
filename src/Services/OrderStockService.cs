using BackendTeamwork.Abstractions;
using BackendTeamwork.Entities;

namespace BackendTeamwork.Services
{
    public class OrderStockService : IOrderStockService
    {
        private IOrderStockRepository _orderStockRepository;

        public OrderStockService(IOrderStockRepository orderStockRepository)
        {
            _orderStockRepository = orderStockRepository;
        }

        public IEnumerable<OrderStock> FindMany(Guid orderId)
        {
            return _orderStockRepository.FindMany(orderId);
        }
        public async Task<OrderStock> CreateOne(OrderStock newOrderStock)
        {
            return await _orderStockRepository.CreateOne(newOrderStock);
        }

    }
}