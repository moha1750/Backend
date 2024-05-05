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

        public PaymentService(IPaymentRepository PaymentRepository, IMapper mapper)
        {
            _paymentRepository = PaymentRepository;
            _mapper = mapper;
        }
        public async Task<PaymentReadDto?> FindOne(Guid paymentId)
        {
            return _mapper.Map<PaymentReadDto>(await _paymentRepository.FindOne(paymentId));
        }
        public async Task<PaymentReadDto> CreateOne(PaymentCreateDto newPayment)
        {
            return _mapper.Map<PaymentReadDto>(await _paymentRepository.CreateOne(_mapper.Map<Payment>(newPayment)));
        }
    }
}