using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BackendTeamwork.Entities;

namespace BackendTeamwork.Databases
{
    public class DatabaseContext
    {
        public List<string> orders;

        public DatabaseContext()
        {
            this.orders = ["order1",
                            "order2",
                            "order3",
                            "order4",
                            "order5",
                            ];
        }

    }
}