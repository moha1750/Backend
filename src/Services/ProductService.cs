#pragma warning disable CS8602
using AutoMapper;
using BackendTeamwork.Abstractions;
using BackendTeamwork.Databases;
using BackendTeamwork.DTOs;
using BackendTeamwork.Entities;
using BackendTeamwork.Enums;
using BackendTeamwork.Exceptions;
using Microsoft.EntityFrameworkCore;


namespace BackendTeamwork.Services
{
    public class ProductService : IProductService
    {

        private IProductRepository _productRepository;
        private DatabaseContext _databaseContext;
        private IStockService _stockService;
        private IMapper _mapper;

        public ProductService(IProductRepository productRepository, IMapper mapper, DatabaseContext databaseContext, IStockService stockService)
        {
            _productRepository = productRepository;
            _databaseContext = databaseContext;
            _mapper = mapper;
            _stockService = stockService;
        }


        public IEnumerable<ProductReadDto> FindMany(int limit, int offset, SortBy sortBy, string? searchTerm)
        {
            return _productRepository.FindMany(limit, offset, sortBy, searchTerm).Select(_mapper.Map<ProductReadDto>);
        }

        public async Task<ProductReadDto?> FindOne(Guid productId)
        {
            return _mapper.Map<ProductReadDto>(await _productRepository.FindOne(productId));
        }

        public async Task<ProductReadDto> CreateOne(ProductCreateDto newProduct)
        {
            if (newProduct.Name.Length < 1 || newProduct.Description.Length < 1
            || newProduct.Image.Length < 1) throw CustomErrorException.InvalidData("Invalid input");

            using (var transaction = _databaseContext.Database.BeginTransaction())
            {
                try
                {
                    Product product = await _productRepository.CreateOne(_mapper.Map<Product>(newProduct));
                    if (newProduct.NewStocks is not null)
                    {
                        IEnumerable<StockCreateDto> stocks = newProduct.NewStocks.Select(_mapper.Map<StockCreateDto>);

                        foreach (StockCreateDto stock in stocks)
                        {
                            stock.ProductId = product.Id;
                            await _stockService.CreateOne(stock);
                        }
                    }

                    transaction.Commit();
                    return _mapper.Map<ProductReadDto>(product);
                }
                catch (DbUpdateException ex)
                {
                    Console.WriteLine(ex.InnerException.Message);
                    throw;
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    throw new Exception("Something went wrong");
                }
            }
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