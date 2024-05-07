using AutoMapper;
using BackendTeamwork.Abstractions;
using BackendTeamwork.DTOs;
using BackendTeamwork.Entities;
using BackendTeamwork.Repositories;

namespace BackendTeamwork.Services
{
    public class ShippingService : IShippingService
    {

        private IShippingRepository _shippingRepository;
        private IMapper _mapper;

        public ShippingService(IShippingRepository shippingRepository, IMapper mapper)
        {
            _shippingRepository = shippingRepository;
            _mapper = mapper;
        }

        public async Task<ShippingReadDto?> FindOneByOrderId(Guid orderId)
        {
            return _mapper.Map<ShippingReadDto>(await _shippingRepository.FindOneByOrderId(orderId));
        }

        public async Task<ShippingReadDto?> FindOne(Guid shippingId)
        {
            return _mapper.Map<ShippingReadDto>(await _shippingRepository.FindOne(shippingId));
        }

        public async Task<ShippingReadDto?> CreateOne(ShippingCreateDto newShipping)
        {
            Shipping? shipping = await _shippingRepository.FindOneByOrderId(newShipping.OrderId);
            if (shipping is not null) return null;

            return _mapper.Map<ShippingReadDto>(await _shippingRepository.CreateOne(_mapper.Map<Shipping>(newShipping)));
        }

        public async Task<ShippingReadDto?> UpdateOne(Guid shippingId, ShippingUpdateDto updatedShipping)
        {
            Shipping? oldShipping = await _shippingRepository.FindOne(shippingId);
            if (oldShipping is null) return null;

            Shipping shipping = _mapper.Map<Shipping>(updatedShipping);
            shipping.Id = shippingId;
            return _mapper.Map<ShippingReadDto>(await _shippingRepository.UpdateOne(shipping));
        }

        public async Task<ShippingReadDto?> DeleteOne(Guid shippingId)
        {
            Shipping? targetShipping = await _shippingRepository.FindOne(shippingId);
            if (targetShipping is null) return null;
            return _mapper.Map<ShippingReadDto>(await _shippingRepository.DeleteOne(targetShipping));
        }
    }
}