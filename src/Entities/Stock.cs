using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackendTeamwork.Entities
{
    public class Stock
    {
        public Guid Id { get; set; }

        public int Quantity { get; set; }

        public string Size { get; set; }

        public string Color { get; set; }

        public Guid Product_id { get; set; }

        public Stock(Guid id, int quantity, string size, string color)
        {
            Id = id;
            Quantity = quantity;
            Size = size;
            Color = color;
            Product_id = new Guid();
        }

    }
}