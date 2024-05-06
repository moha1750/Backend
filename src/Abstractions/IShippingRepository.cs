using BackendTeamwork.Entities;

namespace BackendTeamwork.Abstractions
{
    public interface IShippingRepository
    {
        public IEnumerable<Shipping> FindMany(int limit, int offset);
        public Task<Shipping?> FindOne(Guid shippingId);

        public Task<Shipping> CreateOne(Shipping newShipping);

        public Task<Shipping> UpdateOne(Shipping updatedShipping);

        public Task<Shipping> DeleteOne(Shipping targetShippings);
    }
}