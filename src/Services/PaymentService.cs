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
        public async Task<Payment?> FindOne(Guid paymentId)
        {
            return await _paymentRepository.FindOne(paymentId);
        }
        public async Task<Payment> CreateOne(Payment newPayment)
        {
            return await _paymentRepository.CreateOne(newPayment);
        }
    }
}