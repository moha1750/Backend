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

        public Stock? FindOne(Guid id);

        // createOne
        public Stock CreateOne(Stock newStock);

        // updateOne
        public Stock? UpdateOne(Stock updateStock);

        // deleteOne
        public void DeleteOne(Guid id);

    }
}