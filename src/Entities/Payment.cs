using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackendTeamwork.Entities
{
    public class Payment
    {

        public Guid Id { get; set; }
        public int Amount { get; set; }
        public string Method { get; set; }
        public DateTime Date { get; set; }
        public Guid UserId { get; set; }

        public Payment(Guid id, int amount, string method, DateTime date, Guid userId)
        {
            Id = id;
            Amount = amount;
            Method = method;
            Date = date;
            UserId = userId;
        }
    }

}