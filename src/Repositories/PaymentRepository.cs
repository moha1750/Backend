using BackendTeamwork.Abstractions;
using BackendTeamwork.Databases;
using BackendTeamwork.Entities;
using Microsoft.EntityFrameworkCore;

namespace BackendTeamwork.Repositories
{
    public class PaymentRepository : IPaymentRepository
    {

        private DbSet<Payment> _payments;
        private DatabaseContext _databaseContext;
        public PaymentRepository(DatabaseContext databaseContext)
        {

            _payments = databaseContext.Payments;
            _databaseContext = databaseContext;
        }
        public async Task<Payment?> FindOne(Guid id)
        {

            return await _payments.FirstOrDefaultAsync(payment => payment.Id == id);
        }
        public async Task<Payment> CreateOne(Payment newPayment)
        {
            await _payments.AddAsync(newPayment);
            await _databaseContext.SaveChangesAsync();
            return newPayment;
        }
    }

}