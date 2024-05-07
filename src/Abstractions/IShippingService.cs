using BackendTeamwork.DTOs;
using BackendTeamwork.Entities;

namespace BackendTeamwork.Abstractions
{
    public interface IShippingService
    {
        public IEnumerable<ShippingReadDto> FindMany(int limit, int offset);

        public Task<ShippingReadDto?> FindOne(Guid shippingId);

        public Task<ShippingReadDto> CreateOne(ShippingCreateDto newShipping);

        public Task<ShippingReadDto?> UpdateOne(Guid ShippingId, ShippingUpdateDto updatedShipping);

        public Task<ShippingReadDto?> DeleteOne(Guid shippingId);
    }
}