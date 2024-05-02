using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BackendTeamwork.Abstractions;
using BackendTeamwork.Entities;
using Microsoft.AspNetCore.Mvc;

namespace BackendTeamwork.Controllers
{
    public class CategoriesController : BaseController
    {
        private ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<Category>> FindMany()
        {
            return Ok(_categoryService.FindMany());
        }

        [HttpGet(":{categoryId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Category>> FindOne(Guid categoryId)
        {
            Category? category = await _categoryService.FindOne(categoryId);
            if (category is not null)
            {
                return Ok(category);
            }
            return NotFound();
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<Category>> CreateOne(Category newCategory)
        {
            return Ok(await _categoryService.CreateOne(newCategory));
        }

        [HttpPut(":{categoryId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Category?>> UpdateOne(Guid categoryId, Category updateCategory)
        {
            Category? targetCategory = await _categoryService.UpdateOne(categoryId, updateCategory);
            if (targetCategory is not null)
            {
                return Ok(targetCategory);
            }
            return NotFound();
        }

        [HttpDelete(":{categoryId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Category>> DeleteOne(Guid categoryId)
        {
            Category? deletedCategory = await _categoryService.DeleteOne(categoryId);
            if (deletedCategory is not null)
            {
                return Ok(deletedCategory);
            }
            return NotFound();
        }
    }
}