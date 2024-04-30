using BackendTeamwork.Entities;
using BackendTeamwork.Databases;
using BackendTeamwork.Abstractions;

namespace BackendTeamwork.Repositories
{
    public class OrderRepository : IOrderRepository
    {

        private IEnumerable<Order> _orders;

        public OrderRepository(IEnumerable<Order> orders)
        {
            _orders = new DatabaseContext().Orders;
        }

        public IEnumerable<Order> FindMany(Guid userId)
        {
            return _orders.Where(order => order.UserId == userId);
        }

        public Order? FindOne(Guid id)
        {
            return _orders.FirstOrDefault(order => order.Id == id);
        }

        public Order CreateOne(Order newOrder)
        {
            _orders = _orders.Append(newOrder);
            return newOrder;
        }
    }
}