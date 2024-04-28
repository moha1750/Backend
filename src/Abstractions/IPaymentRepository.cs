
using BackendTeamwork.Entities;

namespace BackendTeamwork.Abstractions
{
    public interface IPaymentRepository
    {
        public Payment? FindOne(Guid id);
        public Payment CreateOne();
    }
}