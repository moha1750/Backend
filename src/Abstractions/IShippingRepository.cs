using BackendTeamwork.Entities;

namespace BackendTeamwork.Abstractions
{
    public interface IShippingRepository
    {
        public IEnumerable<Shipping> FindMany(int limit, int offset);
        public Task<Shipping?> FindOne(Guid productId);

        public Task<Shipping> CreateOne(Shipping newProduct);

        public Task<Shipping> UpdateOne(Shipping updatedShipping);

        public Task<Shipping> DeleteOne(Shipping targetShippings);
    }
}