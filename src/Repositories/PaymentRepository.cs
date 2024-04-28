using BackendTeamwork.Abstractions;
using BackendTeamwork.Databases;
using BackendTeamwork.Entities;

namespace BackendTeamwork.Repositories
{
    public class PaymentRepository : IPaymentRepository
    {

        public Payment? FindOne(Guid id)
        {
            return new DatabaseContext().Payments.FirstOrDefault(payment => payment.Id == id);
        }
        public Payment CreateOne()
        {
            return new DatabaseContext().Payments.First();
        }
    }

}