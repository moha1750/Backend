using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using BackendTeamwork.Abstractions;
using BackendTeamwork.Entities;
using BackendTeamwork.Databases;

namespace BackendTeamwork.Services
{
    public class OrderService : IOrderService
    {
        private IOrderRepository _orderRepository;

        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public List<string> FindAll()
        {
            return _orderRepository.FindAll();
        }
    }
}