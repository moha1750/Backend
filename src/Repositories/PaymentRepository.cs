using BackendTeamwork.Abstractions;
using BackendTeamwork.Databases;
using BackendTeamwork.Entities;

namespace BackendTeamwork.Repositories
{
    public class PaymentRepository : IPaymentRepository
    {

        public IEnumerable<Payment> FindOne()
        {
            return new DatabaseContext().Payments;
        }
        public IEnumerable<Payment> CreateOne()
        {
            return new DatabaseContext().Payments;
        }
    }

}