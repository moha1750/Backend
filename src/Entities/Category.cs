using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackendTeamwork.Entities
{
    public class Category
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public Category(Guid id, string name, string description)
        {
            Id = id;
            Name = name;
            Description = description;
        }

    }
}