using DPA.SHOPPING.CORE.Core.DTOs;
using DPA.SHOPPING.CORE.Core.Entities;
using DPA.SHOPPING.CORE.Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DPA.SHOPPING.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;            
        }

        [HttpGet]
        public async Task<IActionResult> GetCategories()
        {
            var categories = await _categoryService.GetCategories();
            return Ok(categories);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategoryById(int id)
        {
            var category = await _categoryService.GetCategoryById(id);
            if (category == null)
            {
                return NotFound();
            }
            return Ok(category);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategory([FromBody] CreateCategoryDTO createCategoryDTO)
        {
            await _categoryService.CreateCategory(createCategoryDTO);
            return NoContent();
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCategory(int id, [FromBody] UpdateCategoryDTO updateCategoryDTO)
        {
            var existingCategory = await _categoryService.GetCategoryById(id);
            if (existingCategory == null)
            {
                return NotFound();
            }
            await _categoryService.UpdateCategory(updateCategoryDTO);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory([FromBody] DeleteCategoryDTO deleteCategoryDTO)
        {
            var existingCategory = await _categoryService.GetCategoryById(deleteCategoryDTO.Id);
            if (existingCategory == null)
            {
                return NotFound();
            }
            await _categoryService.DeleteCategory(deleteCategoryDTO);
            return NoContent();
        }
    }
}
