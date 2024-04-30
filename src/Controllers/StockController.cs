using System.Runtime.CompilerServices;
using BackendTeamwork.Abstractions;
using BackendTeamwork.Entities;
using Microsoft.AspNetCore.Mvc;

namespace BackendTeamwork.Controllers
{
    public class StockController : BaseController
    {

        private IStockService _stockService;

        public StockController(IStockService stockService)
        {
            _stockService = stockService;
        }

        // createOne
        [HttpPost]
        public ActionResult<Stock> CreateOne(Stock newStock)
        {
            if (newStock is not null)
            {
                return Ok(_stockService.CreateOne(newStock));
            }
            return BadRequest();
        }

        // updateOne
        [HttpPut("/id")]
        public ActionResult<Stock?> UpdateOne(Guid id, Stock updateStock)
        {
            return Ok(_stockService.UpdateOne(id, updateStock));
        }

        // deleteOne
        [HttpDelete("/id")]
        public ActionResult DeleteOne(Guid id)
        {
            return NoContent();
        }

    }
}