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

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<Stock>> FindMany()
        {
            return Ok(_stockService.FindMany());
        }

        [HttpGet("productId")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<Stock>> FindMany(Guid productId)
        {
            return Ok(_stockService.FindMany(productId));
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Stock>> CreateOne([FromBody] Stock newStock)
        {
            if (newStock is not null)
            {
                await _stockService.CreateOne(newStock);
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