
using BackendTeamwork.Entities;

namespace BackendTeamwork.Abstractions
{
    public interface IPaymentRepository
    {
        public IEnumerable<Payment> FindOne();
        public IEnumerable<Payment> CreateOne();
    }
}