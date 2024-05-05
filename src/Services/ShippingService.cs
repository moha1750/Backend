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

        public IEnumerable<ShippingReadDto> FindMany(int limit, int offset)
        {
            return _shippingRepository.FindMany(limit, offset).Select(_mapper.Map<ShippingReadDto>);
        }

        public async Task<ShippingReadDto?> FindOne(Guid shippingId)
        {
            return _mapper.Map<ShippingReadDto>(await _shippingRepository.FindOne(shippingId));
        }

        public async Task<ShippingReadDto> CreateOne(ShippingCreateDto newShipping)
        {
            return _mapper.Map<ShippingReadDto>(await _shippingRepository.CreateOne(_mapper.Map<Shipping>(newShipping)));
        }

        public async Task<ShippingReadDto?> UpdateOne(Guid shippingId, ShippingUpdateDto updatedShipping)
        {
            Shipping? oldShipping = await _shippingRepository.FindOne(shippingId);
            if (oldShipping is null)
            {
                return null;
            }
            Shipping shipping = _mapper.Map<Shipping>(updatedShipping);
            shipping.Id = shippingId;
            return _mapper.Map<ShippingReadDto>(await _shippingRepository.UpdateOne(shipping));
        }

        public async Task<ShippingReadDto?> DeleteOne(Guid shippingId)
        {
            Shipping? targetShipping = await _shippingRepository.FindOne(shippingId);
            if (targetShipping is not null)
            {
                return _mapper.Map<ShippingReadDto>(await _shippingRepository.DeleteOne(targetShipping));
            }
            return null;
        }
    }
}