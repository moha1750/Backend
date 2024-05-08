using AutoMapper;
using BackendTeamwork.DTOs;
using BackendTeamwork.Entities;
namespace BackendTeamwork.Mappers
{
    public class Mapper : Profile
    {
        public Mapper()
        {
            CreateMap<User, UserReadDto>();
            CreateMap<UserReadDto, User>();

            CreateMap<AddressCreateDto, Address>();
            CreateMap<CategoryCreateDto, Category>();
            CreateMap<OrderCreateDto, Order>();
            CreateMap<OrderStockCreateDto, OrderStock>();
            CreateMap<PaymentCreateDto, Payment>();
            CreateMap<ProductCreateDto, Product>();
            CreateMap<ReviewCreateDto, Review>();
            CreateMap<StockCreateDto, Stock>();
            CreateMap<UserCreateDto, User>();
            CreateMap<WishlistCreateDto, Wishlist>();
            CreateMap<ShippingCreateDto, Shipping>();

            CreateMap<AddressUpdateDto, Address>();
            CreateMap<CategoryUpdateDto, Category>();
            CreateMap<OrderUpdateDto, Order>();
            // CreateMap<OrderStockUpdateDto, OrderStock>();
            // CreateMap<PaymentUpdateDto, Payment>();
            CreateMap<ProductUpdateDto, Product>();
            CreateMap<ReviewUpdateDto, Review>();
            CreateMap<StockUpdateDto, Stock>();
            CreateMap<UserUpdateDto, User>();
            CreateMap<WishlistUpdateDto, Wishlist>();
            CreateMap<ShippingUpdateDto, Shipping>();

            CreateMap<Address, AddressReadDto>();
            CreateMap<Category, CategoryReadDto>();
            CreateMap<Order, OrderReadDto>();
            CreateMap<OrderStock, OrderStockReadDto>();
            CreateMap<Payment, PaymentReadDto>();
            CreateMap<Product, ProductReadDto>();
            CreateMap<Review, ReviewReadDto>();
            CreateMap<Stock, StockReadDto>();
            CreateMap<User, UserReadDto>();
            CreateMap<Wishlist, WishlistReadDto>();
            CreateMap<Shipping, ShippingReadDto>();


            CreateMap<OrderStockReduceDto, OrderStockCreateDto>();
            CreateMap<OrderStockReduceDto, OrderStock>();
            CreateMap<OrderStock, OrderStockReduceDto>();

        }
    }
}