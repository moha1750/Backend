using BackendTeamwork.Abstractions;
using BackendTeamwork.Entities;
using Microsoft.AspNetCore.Mvc;

namespace BackendTeamwork.Controllers
{
    public class ProductsController : BaseController
    {

        private IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<Product>> FindMany()
        {
            return Ok(_productService.FindMany());
        }

        [HttpGet(":productId")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<Product>> FindOne(Guid productId)
        {
            Product? targetProduct = await _productService.FindOne(productId);
            if (targetProduct is not null)
            {
                return Ok(targetProduct);
            }
            return NotFound();
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Product> CreateOne([FromBody] Product newProduct)
        {
            if (newProduct is not null)
            {
                _productService.CreateOne(newProduct);
                return CreatedAtAction(nameof(CreateOne), newProduct);
            }
            return BadRequest();
        }

        [HttpPut(":productId")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Product?>> UpdateOne([FromQuery] Guid productId, [FromBody] Product updatedProduct)
        {
            Product? targetProduct = await _productService.UpdateOne(productId, updatedProduct);
            if (targetProduct is not null)
            {
                return Ok(updatedProduct);
            }
            return NotFound();
        }


        [HttpDelete(":productId")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Product>> DeleteOne(Guid productId)
        {
            Product? deletedProduct = await _productService.DeleteOne(productId);
            if (deletedProduct is not null)
            {
                return Ok(deletedProduct);
            }
            return NotFound();
        }

    }
}
