using BackendTeamwork.Entities;
using BackendTeamwork.Databases;
using BackendTeamwork.Abstractions;
using Microsoft.EntityFrameworkCore;
using BackendTeamwork.Enums;

namespace BackendTeamwork.Repositories
{
    public class OrderRepository : IOrderRepository
    {

        private DbSet<Order> _orders;
        private DatabaseContext _databaseContext;

        public OrderRepository(DatabaseContext databaseContext)
        {
            _orders = databaseContext.Order;
            _databaseContext = databaseContext;

        }

        public IEnumerable<Order> FindMany(Guid userId, SortBy sortBy = SortBy.Ascending)
        {
            if (sortBy == SortBy.Ascending)
            {
                return _orders.Where(order => order.UserId == userId);
            }
            else
            {
                return _orders.OrderByDescending((Order) => Order.UserId == userId);
            }
            // return _orders.Where(order => order.UserId == userId);
        }

        public async Task<Order?> FindOne(Guid id)
        {
            return await _orders.AsNoTracking().FirstOrDefaultAsync(order => order.Id == id);
        }

        public async Task<Order> CreateOne(Order newOrder)
        {
            await _orders.AddAsync(newOrder);
            await _databaseContext.SaveChangesAsync();
            return newOrder;
        }
    }
}