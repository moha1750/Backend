using System.Security.Cryptography.X509Certificates;
using BackendTeamwork.Abstractions;
using BackendTeamwork.Entities;

namespace BackendTeamwork.Repositories
{
    public class OrderStockRepository : IOrderStockRepository
    {
        private IEnumerable<OrderStock> _orderStocks;

        public OrderStockRepository(IEnumerable<OrderStock> orderStocks)
        {
            _orderStocks = orderStocks;
        }

        public IEnumerable<OrderStock> FindMany(Guid orderId)
        {
            return _orderStocks.Where(orderStock => orderStock.StockId == orderId);
        }

        public OrderStock CreateOne(OrderStock newOrderStock)
        {
            _orderStocks.Append(newOrderStock);

            return newOrderStock;
        }


    }
}