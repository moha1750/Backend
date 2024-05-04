using BackendTeamwork.Abstractions;
using BackendTeamwork.DTOs;
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
        public ActionResult<IEnumerable<StockReadDto>> FindMany()
        {
            return Ok(_stockService.FindMany());
        }

        [HttpGet(":{productId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<StockReadDto>> FindMany(Guid productId)
        {
            return Ok(_stockService.FindMany(productId));
        }

        // [HttpGet(":{stockId}")]
        // [ProducesResponseType(StatusCodes.Status200OK)]
        // [ProducesResponseType(StatusCodes.Status400BadRequest)]
        // public async Task<ActionResult<Stock>> FindOne(Guid stockId)
        // {
        //     Stock? stock = await _stockService.FindOne(stockId);
        //     if (stock is not null)
        //     {
        //         return Ok(stock);
        //     }
        //     return NotFound();
        // }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<StockReadDto>> CreateOne([FromBody] StockCreateDto newStock)
        {
            if (newStock is not null)
            {
                await _stockService.CreateOne(newStock);
                return CreatedAtAction(nameof(CreateOne), newStock);
            }
            return BadRequest();
        }


        [HttpPut(":{stockId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult<StockReadDto>> UpdateOne(Guid stockId, [FromBody] StockUpdateDto updatedStock)
        {
            StockReadDto? targetStock = await _stockService.UpdateOne(stockId, updatedStock);
            if (targetStock is not null)
            {
                return Ok(updatedStock);
            }
            return NoContent();
        }

        [HttpDelete(":{stockId}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> DeleteOne(Guid stockId)
        {
            Stock? stock = await _stockService.DeleteOne(stockId);
            if (stock is not null)
            {
                return NoContent();
            }
            return NotFound();
        }

    }
}