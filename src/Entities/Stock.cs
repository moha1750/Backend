using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BackendTeamwork.Entities
{
    public class Stock
    {
        public Guid Id { get; set; }
        [Required]
        public int Quantity { get; set; }
        public string Size { get; set; }
        public string Color { get; set; }
        public Guid ProductId { get; set; }
        public IEnumerable<OrderStock> OrderStocks { get; set; }

    }
}