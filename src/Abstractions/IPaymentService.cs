
using BackendTeamwork.Entities;

namespace BackendTeamwork.Abstractions
{
    public interface IPaymentService
    {
        public Payment? FindOne(Guid id);
        public Payment CreateOne(Payment newPayment);

    }
}