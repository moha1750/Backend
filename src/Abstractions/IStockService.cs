using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BackendTeamwork.Entities;

namespace BackendTeamwork.Abstractions
{
    public interface IStockService
    {

        public IEnumerable<Stock> FindMany();

        public Stock CreateOne(Stock newStock);

        public Stock? UpdateOne(Guid stockId, Stock updatedStock);

        public void DeleteOne(Guid stockId);
    }
}
