using AutoMapper;
using BackendTeamwork.Abstractions;
using BackendTeamwork.DTOs;
using BackendTeamwork.Entities;

namespace BackendTeamwork.Services
{
    public class OrderStockService : IOrderStockService
    {
        private IOrderStockRepository _orderStockRepository;
        private IMapper _mapper;

        public OrderStockService(IOrderStockRepository orderStockRepository, IMapper mapper)
        {
            _orderStockRepository = orderStockRepository;
            _mapper = mapper;
        }

        public IEnumerable<OrderStock> FindMany(Guid orderId)
        {
            return _orderStockRepository.FindMany(orderId);
        }
        public async Task<OrderStock> CreateOne(OrderStock newOrderStock)
        {
            return await _orderStockRepository.CreateOne(newOrderStock);
        }

        public async Task<IEnumerable<OrderStockReadDto>> CreateMany(IEnumerable<OrderStockCreateDto> newOrderStocks)
        {
            IEnumerable<OrderStock> orderStocks = await _orderStockRepository.CreateMany(newOrderStocks.Select(_mapper.Map<OrderStock>));

            return orderStocks.Select(_mapper.Map<OrderStockReadDto>);
        }


    }
}