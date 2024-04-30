using BackendTeamwork.Abstractions;
using BackendTeamwork.Entities;
using Microsoft.AspNetCore.Mvc;

namespace BackendTeamwork.Controllers
{
    public class OrdersController : BaseController
    {

        private IOrderService _orderService;

        public OrdersController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet]
        public IEnumerable<Order> FindMany([FromQuery] Guid userId)
        {
            return _orderService.FindMany(userId);
        }

        [HttpGet(":{id}")]
        public Order? FindOne(Guid id)
        {
            return _orderService.FindOne(id);
        }

        [HttpPost]
        public Order CreateOne([FromBody] Order newOrder)
        {
            return _orderService.CreateOne(newOrder);
        }

    }
}