using AutoMapper;
using BackendTeamwork.Abstractions;
using BackendTeamwork.DTOs;
using BackendTeamwork.Entities;
using BackendTeamwork.Repositories;

namespace BackendTeamwork.Services
{
    public class StockService : IStockService
    {

        private IStockRepository _stockRepository;
        private IMapper _mapper;

        public StockService(IStockRepository stockRepository, IMapper mapper)
        {
            _stockRepository = stockRepository;
            _mapper = mapper;
        }

        public IEnumerable<StockReadDto> FindMany(int limit, int offset)
        {
            return _stockRepository.FindMany(limit, offset).Select(_mapper.Map<StockReadDto>);
        }

        public IEnumerable<StockReadDto> FindMany(Guid productId)
        {
            return _stockRepository.FindMany(productId).Select(_mapper.Map<StockReadDto>);
        }

        public async Task<StockReadDto?> FindOne(Guid stockId)
        {
            return _mapper.Map<StockReadDto>(await _stockRepository.FindOne(stockId));
        }

        public async Task<StockReadDto> CreateOne(StockCreateDto newStock)

        {
            return _mapper.Map<StockReadDto>(await _stockRepository.CreateOne(_mapper.Map<Stock>(newStock)));
        }

        public async Task<StockReadDto?> UpdateOne(Guid stockId, StockUpdateDto updatedStock)
        {
            Stock? targetStock = await _stockRepository.FindOne(stockId);
            if (targetStock is null)
            {
                return null;
            }
            Stock stock = _mapper.Map<Stock>(updatedStock);
            stock.Id = stockId;
            return _mapper.Map<StockReadDto>(await _stockRepository.UpdateOne(stock));
        }

        public async Task<Stock?> DeleteOne(Guid stockId)
        {
            Stock? stock = await _stockRepository.FindOne(stockId);
            if (stock is not null)
            {
                return await _stockRepository.DeleteOne(stock);
            }
            return null;
        }

        public async Task<Stock> ReduceOne(OrderStockReduceDto orderStock)
        {
            return await _stockRepository.ReduceOne(orderStock);
        }

    }
}