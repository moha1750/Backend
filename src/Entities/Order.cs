using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BackendTeamwork.Entities
{
    public class Order
    {

        public Guid Id { get; set; }
        [Required]
        public string? Status { get; set; }
        public DateTime Date { get; set; }
        public Guid PaymentId { get; set; }
        public Guid UserId { get; set; }
        public IEnumerable<OrderStock> OrderStocks { get; set; }

    }
}