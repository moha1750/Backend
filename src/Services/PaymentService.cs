using AutoMapper;
using BackendTeamwork.Abstractions;
using BackendTeamwork.DTOs;
using BackendTeamwork.Entities;

namespace BackendTeamwork.Controllers
{
    public class PaymentService : IPaymentService
    {
        private IPaymentRepository _paymentRepository;
        private IMapper _mapper;
        private IOrderService _orderService;

        private IOrderStockService _orderStockService;
        private IStockService _stockService;

        public PaymentService(IPaymentRepository PaymentRepository, IMapper mapper, IOrderService orderService, IOrderStockService orderStockService, IStockService stockService)
        {
            _paymentRepository = PaymentRepository;
            _mapper = mapper;
            _orderService = orderService;
            _orderStockService = orderStockService;
            _stockService = stockService;
        }
        public async Task<PaymentReadDto?> FindOne(Guid paymentId)
        {
            return _mapper.Map<PaymentReadDto>(await _paymentRepository.FindOne(paymentId));
        }


        public async Task<PaymentReadDto> CreateOne(PaymentCreateDto newPayment)
        {
            PaymentReadDto payment = _mapper.Map<PaymentReadDto>(await _paymentRepository.CreateOne(_mapper.Map<Payment>(newPayment)));

            OrderCreateDto orderDetails = new OrderCreateDto
            {
                Status = "Pending",
                PaymentId = payment.Id,
                UserId = payment.UserId
            };
            OrderReadDto order = await _orderService.CreateOne(orderDetails);

            IEnumerable<OrderStock> orderStock = newPayment.Items.Select(_mapper.Map<OrderStock>);

            foreach (OrderStock item in orderStock)
            {
                item.OrderId = order.Id;
                Stock stock = await _stockService.ReduceOne(_mapper.Map<OrderStockReduceDto>(item));
                item.Price = stock.Price;
                await _orderStockService.CreateOne(item);
            }

            return payment;

        }
    }
}