using BackendTeamwork.DTOs;
using BackendTeamwork.Entities;

namespace BackendTeamwork.Abstractions
{
    public interface IShippingService
    {
        public Task<ShippingReadDto?> FindOneByOrderId(Guid orderId);
        public Task<ShippingReadDto?> FindOne(Guid shippingId);
        public Task<ShippingReadDto?> CreateOne(ShippingCreateDto newShipping);
        public Task<ShippingReadDto?> UpdateOne(Guid ShippingId, ShippingUpdateDto updatedShipping);
        public Task<ShippingReadDto?> DeleteOne(Guid shippingId);
    }
}