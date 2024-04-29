using BackendTeamwork.Abstractions;
using BackendTeamwork.Databases;
using BackendTeamwork.Entities;

namespace BackendTeamwork.Repositories
{
    public class PaymentRepository : IPaymentRepository
    {
        private IEnumerable<Payment> _payments;
        public PaymentRepository()
        {
            _payments = new DatabaseContext().Payments;
        }

        public Payment? FindOne(Guid id)
        {
            return _payments.FirstOrDefault(payment => payment.Id == id);
        }
        public Payment CreateOne(Payment newPayment)
        {
            _payments = _payments.Append(newPayment);
            return newPayment;
        }
    }

}