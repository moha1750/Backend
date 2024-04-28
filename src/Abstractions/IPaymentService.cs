
using BackendTeamwork.Entities;

namespace BackendTeamwork.Abstractions
{
    public interface IPaymentService
    {
        public Payment FindOne();
        public Payment CreateOne();

    }
}