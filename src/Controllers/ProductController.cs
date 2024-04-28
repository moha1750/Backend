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

        // updateOne

        // deleteOne



    }
}