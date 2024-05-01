
using BackendTeamwork.Entities;

namespace BackendTeamwork.Abstractions
{
    public interface IPaymentService
    {
        public Task<Payment?> FindOne(Guid id);
        public Task<Payment> CreateOne(Payment newPayment);

    }
}