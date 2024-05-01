using BackendTeamwork.Abstractions;
using BackendTeamwork.Entities;

namespace BackendTeamwork.Controllers
{
    public class PaymentService : IPaymentService
    {
        private IPaymentRepository _paymentRepository;

        public PaymentService(IPaymentRepository PaymentRepository)
        {
            _paymentRepository = PaymentRepository;
        }
        public async Task<Payment?> FindOne(Guid id)
        {
            return await _paymentRepository.FindOne(id);
        }
        public async Task<Payment> CreateOne(Payment newPayment)
        {
            return await _paymentRepository.CreateOne(newPayment);
        }
    }
}