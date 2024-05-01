using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using BackendTeamwork.Abstractions;
using BackendTeamwork.Controllers;
using BackendTeamwork.Entities;
using BackendTeamwork.Services;
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
        public ActionResult<Product?> FindOne([FromRoute] Guid productId)
        {
            var targetProduct = _productService.FindOne(productId);
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
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public ActionResult<Product?> UpdateOne([FromRoute] Guid productId, [FromBody] Product updatedProduct)
        {
            var targetProduct = _productService.UpdateOne(productId, updatedProduct);
            if (targetProduct is not null)
            {
                return Ok(updatedProduct);
            }
            return NoContent();
        }


        [HttpDelete(":productId")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public ActionResult DeleteOne([FromRoute] Guid productId)
        {
            _productService.DeleteOne(productId);
            return NoContent();
        }

    }
}
