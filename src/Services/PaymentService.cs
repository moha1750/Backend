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

        public Payment? FindOne(Guid id)
        {
            return _paymentRepository.FindOne(id);
        }
        public Payment CreateOne()
        {
            return _paymentRepository.CreateOne();
        }


    }


}