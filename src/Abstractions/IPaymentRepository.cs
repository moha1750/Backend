
using BackendTeamwork.Entities;

namespace BackendTeamwork.Abstractions
{
    public interface IPaymentRepository
    {
        public Task<Payment?> FindOne(Guid id);
        public Task<Payment> CreateOne(Payment newPayment);
    }
}