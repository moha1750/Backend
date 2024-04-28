using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BackendTeamwork.Abstractions;
using BackendTeamwork.Controllers;
using BackendTeamwork.Entities;
using BackendTeamwork.Services;
using Microsoft.AspNetCore.Mvc;

namespace BackendTeamwork.Controllers
{
    public class ProductController : BaseController
    {

        private IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        // findMany
        [HttpGet]
        public IEnumerable<Product> FindMany()
        {
            return _productService.FindMany();
        }

        // findOne
        [HttpGet(":productId")]
        public Product? FindOne(Guid id)
        {
            return _productService.FindOne(id);
        }

        // createOne
        [HttpPost]
        public ActionResult<Product> CreateOne([FromBody] Product newProduct)
        {
            if (newProduct is not null)
            {
                _productService.CreateOne(newProduct);
                return CreatedAtAction(nameof(CreateOne), newProduct);
            }
            return BadRequest();
        }

        // updateOne
        [HttpPut(":productId")]
        public ActionResult<Product> UpdateOne(Guid id, [FromBody] Product updatedProduct)
        {
            _productService.UpdateOne(id, updatedProduct);
            return new OkObjectResult(updatedProduct);
        }


        // deleteOne




    }
}