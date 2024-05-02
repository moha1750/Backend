using BackendTeamwork.Entities;
using BackendTeamwork.Databases;
using BackendTeamwork.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace BackendTeamwork.Repositories
{
    public class OrderRepository : IOrderRepository
    {

        private IEnumerable<Order> _orders;
        private DatabaseContext _databaseContext;

        public OrderRepository(DatabaseContext databaseContext)
        {
            _orders = databaseContext.Orders;
            _databaseContext = databaseContext;

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