using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BackendTeamwork.Entities;

namespace BackendTeamwork.Abstractions
{
    public interface IStockRepository
    {

        //findMany
        public IEnumerable<Stock> FindMany();

        public Stock? FindOne(Guid stockId);

        // createOne
        public Stock CreateOne(Stock newStock);

        // updateOne
        public Stock UpdateOne(Stock updatedStock);

        // deleteOne
        public void DeleteOne(Guid stockId);

    }
}