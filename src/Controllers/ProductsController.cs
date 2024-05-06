using BackendTeamwork.Abstractions;
using BackendTeamwork.DTOs;
using BackendTeamwork.Entities;
using Microsoft.AspNetCore.Authorization;
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
        [Authorize(Roles = "Admin, Customer")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<ProductReadDto>> FindMany([FromQuery(Name = "limit")] int limit, [FromQuery(Name = "offset")] int offset)
        {
            return Ok(_productService.FindMany(limit, offset));
        }

        [HttpGet(":productId")]
        [Authorize(Roles = "Admin, Customer")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<ProductReadDto>> FindOne(Guid productId)
        {
            ProductReadDto? targetProduct = await _productService.FindOne(productId);
            if (targetProduct is not null)
            {
                return Ok(targetProduct);
            }
            return NotFound();
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ProductReadDto>> CreateOne([FromBody] ProductCreateDto newProduct)
        {
            return Ok(await _productService.CreateOne(newProduct));
        }

        [HttpPut(":productId")]
        [Authorize(Roles = "Admin")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ProductReadDto?>> UpdateOne([FromQuery] Guid productId, [FromBody] ProductUpdateDto updatedProduct)
        {
            ProductReadDto? targetProduct = await _productService.UpdateOne(productId, updatedProduct);
            if (targetProduct is not null)
            {
                return Ok(updatedProduct);
            }
            return NotFound();
        }


        [HttpDelete(":productId")]
        [Authorize(Roles = "Admin")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ProductReadDto>> DeleteOne(Guid productId)
        {
            ProductReadDto? deletedProduct = await _productService.DeleteOne(productId);
            if (deletedProduct is not null)
            {
                return Ok(deletedProduct);
            }
            return NotFound();
        }

    }
}
