using System.Runtime.CompilerServices;
using BackendTeamwork.Abstractions;
using BackendTeamwork.Entities;
using Microsoft.AspNetCore.Mvc;

namespace BackendTeamwork.Controllers
{
    public class StocksController : BaseController
    {

        private IStockService _stockService;

        public StocksController(IStockService stockService)
        {
            _stockService = stockService;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Stock> CreateOne([FromBody] Stock newStock)
        {
            if (newStock is not null)
            {
                _stockService.CreateOne(newStock);
                return CreatedAtAction(nameof(CreateOne), newStock);
            }
            return BadRequest();
        }


        [HttpPut("stockId")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public ActionResult<Stock?> UpdateOne([FromRoute] Guid stockId, Stock updatedStock)
        {
            var targetStock = _stockService.UpdateOne(stockId, updatedStock);
            if (targetStock is not null)
            {
                return Ok(updatedStock);
            }
            return NoContent();
        }

        [HttpDelete("stockId")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public ActionResult DeleteOne([FromRoute] Guid stockId)
        {
            _stockService.DeleteOne(stockId);
            return NoContent();
        }

    }
}