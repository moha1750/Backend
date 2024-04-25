using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using BackendTeamwork.Abstractions;
using BackendTeamwork.Entities;
using BackendTeamwork.Databases;

namespace BackendTeamwork.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        public List<string> FindAll()
        {
            return new DatabaseContext().orders;
        }
    }
}