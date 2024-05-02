
using BackendTeamwork.Entities;

namespace BackendTeamwork.Abstractions
{
    public interface IPaymentService
    {
        public Task<Payment?> FindOne(Guid paymentId);
        public Task<Payment> CreateOne(Payment newPayment);

    }
}