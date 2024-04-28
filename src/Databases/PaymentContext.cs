using BackendTeamwork.Entities;

namespace BackendTeamwork.Databases
{
    public class PaymentContext(Guid id, int amount, string method, DateTime date, Guid userId)
    {
        public IEnumerable<Payment> Payment;
        [
                   id = new Guid()
                    amount = "123",
                    method = "Cash",
                    date = new DateTime,
                    userId = new Guid(),
                    ]
                    
                    
                }
}
