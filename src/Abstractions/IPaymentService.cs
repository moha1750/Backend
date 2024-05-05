
using BackendTeamwork.DTOs;
using BackendTeamwork.Entities;

namespace BackendTeamwork.Abstractions
{
    public interface IPaymentService
    {
        public Task<PaymentReadDto?> FindOne(Guid paymentId);
        public Task<PaymentReadDto> CreateOne(PaymentCreateDto newPayment);

    }
}