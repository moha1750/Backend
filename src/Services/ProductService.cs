using AutoMapper;
using BackendTeamwork.Abstractions;
using BackendTeamwork.DTOs;
using BackendTeamwork.Entities;
using BackendTeamwork.Enums;
using BackendTeamwork.Exceptions;
using BackendTeamwork.Repositories;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace BackendTeamwork.Services
{
    public class ProductService : IProductService
    {

        private IProductRepository _productRepository;
        private IMapper _mapper;

        public ProductService(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }


        public IEnumerable<ProductReadDto> FindMany(int limit, int offset, SortBy sortBy)
        {
            return _productRepository.FindMany(limit, offset, sortBy).Select(_mapper.Map<ProductReadDto>);
        }

        public async Task<ProductReadDto?> FindOne(Guid productId)
        {
            return _mapper.Map<ProductReadDto>(await _productRepository.FindOne(productId));
        }

        public async Task<ProductReadDto> CreateOne(ProductCreateDto newProduct)
        {
            if (newProduct.Name.Length < 1 || newProduct.Description.Length < 1
            || newProduct.Image.Length < 1) throw CustomErrorException.InvalidData("Invalid input");

            return _mapper.Map<ProductReadDto>(await _productRepository.CreateOne(_mapper.Map<Product>(newProduct)));
        }

        public async Task<ProductReadDto?> UpdateOne(Guid productId, ProductUpdateDto updatedProduct)
        {
            Product? oldProduct = await _productRepository.FindOne(productId);
            if (oldProduct is null) throw CustomErrorException.NotFound("Product is not found");

            Product product = _mapper.Map<Product>(updatedProduct);
            product.Id = productId;
            return _mapper.Map<ProductReadDto>(await _productRepository.UpdateOne(product));
        }

        public async Task<ProductReadDto?> DeleteOne(Guid productId)
        {
            Product? targetProduct = await _productRepository.FindOne(productId);
            if (targetProduct is null) throw CustomErrorException.NotFound("Product is not found");

            return _mapper.Map<ProductReadDto>(await _productRepository.DeleteOne(targetProduct));
        }

        public IEnumerable<ProductReadDto> Search(string searchTerm)
        {
            return _productRepository.Search(searchTerm).Select(_mapper.Map<ProductReadDto>);
        }
    }
}