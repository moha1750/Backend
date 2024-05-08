using BackendTeamwork.Entities;

namespace BackendTeamwork.Abstractions
{
    public interface IShippingRepository
    {
        public Task<Shipping?> FindOneByOrderId(Guid orderId);
        public Task<Shipping?> FindOne(Guid shippingId);
        public Task<Shipping> CreateOne(Shipping newShipping);
        public Task<Shipping> UpdateOne(Shipping updatedShipping);
        public Task<Shipping> DeleteOne(Shipping targetShippings);
    }
}