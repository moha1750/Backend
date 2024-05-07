using AutoMapper;
using BackendTeamwork.Abstractions;
using BackendTeamwork.DTOs;
using BackendTeamwork.Entities;
using BackendTeamwork.Enums;
using BackendTeamwork.Repositories;

namespace BackendTeamwork.Services
{
    public class OrderService : IOrderService
    {

        private IOrderRepository _orderRepository;
        private IMapper _mapper;

        public OrderService(IOrderRepository orderRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
        }

        public IEnumerable<OrderReadDto> FindMany(Guid userId, SortBy sortBy)
        {
            return _orderRepository.FindMany(userId, sortBy).Select(_mapper.Map<OrderReadDto>);
        }

        public async Task<OrderReadDto?> FindOne(Guid orderId)
        {
            return _mapper.Map<OrderReadDto>(await _orderRepository.FindOne(orderId));
        }

        public async Task<OrderReadDto> CreateOne(OrderCreateDto newOrder)
        {
            return _mapper.Map<OrderReadDto>(await _orderRepository.CreateOne(_mapper.Map<Order>(newOrder)));
        }
    }
}