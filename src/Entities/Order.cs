using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackendTeamwork.Entities
{
    public class Order
    {
        public Order(Guid id, string status, DateTime date, Guid paymentId, Guid userId)
        {
            Id = id;
            Status = status;
            Date = date;
            PaymentId = paymentId;
            UserId = userId;
        }

        public Guid Id { get; set; }
        public string Status { get; set; }
        public DateTime Date { get; set; }
        public Guid PaymentId { get; set; }
        public Guid UserId { get; set; }
    }
}