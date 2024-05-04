
using BackendTeamwork.DTOs;
using BackendTeamwork.Entities;

namespace BackendTeamwork.Abstractions
{
    public interface IProductService
    {
        public IEnumerable<ProductReadDto> FindMany();

        public Task<ProductReadDto?> FindOne(Guid productId);

        public Task<ProductReadDto> CreateOne(ProductCreateDto newProduct);

        public Task<ProductReadDto?> UpdateOne(Guid productId, ProductUpdateDto updatedProduct);

        public Task<ProductReadDto?> DeleteOne(Guid productId);
    }
}