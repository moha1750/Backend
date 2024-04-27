using BackendTeamwork.Entities;

namespace BackendTeamwork.Databases
{
    public class OrderContext
    {
        public IEnumerable<Order> Orders;

        public OrderContext()
        {
            this.Orders =
            [
                new Order("test"),
                new Order("test"),
                new Order("test"),
                new Order("test")
            ];
        }

    }
}