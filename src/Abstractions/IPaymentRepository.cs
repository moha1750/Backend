
using BackendTeamwork.Entities;

namespace BackendTeamwork.Abstractions
{
    public interface IPaymentRepository
    {
        public Task<Payment?> FindOne(Guid paymentId);
        public Task<Payment> CreateOne(Payment newPayment);
    }
}