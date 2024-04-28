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

        public IEnumerable<Payment> FindOne()
        {
            return _paymentRepository.FindOne();
        }
        public IEnumerable<Payment> CreateOne()
        {
            return _paymentRepository.CreateOne();
        }

        Payment IPaymentService.FindOne()
        {
            throw new NotImplementedException();
        }

        Payment IPaymentService.CreateOne()
        {
            throw new NotImplementedException();
        }
    }


}