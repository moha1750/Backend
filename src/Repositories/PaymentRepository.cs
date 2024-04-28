using BackendTeamwork.Entities;

namespace BackendTeamwork.Repositories
{
    public class PaymentRepository : IPaymentRepository
    {

        public IEnumerable<Payment> FindAll()
        {
            return new DatabaseContext().Payment;
        }
    }

}