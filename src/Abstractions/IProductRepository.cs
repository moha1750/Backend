
using BackendTeamwork.Entities;

namespace BackendTeamwork.Abstractions
{
    public interface IProductRepository
    {
        public IEnumerable<Product> FindMany();
        public Product? FindOne(Guid id);
    }
}