using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SimpleProductCRUD.API.SemCopilot.DTOs;
using SimpleProductCRUD.API.SemCopilot.Interfaces;

namespace SimpleProductCRUD.API.SemCopilot.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoryDTO>>> Get()
        {
            var categories = await _categoryService.GetAllCategories();
            return Ok(categories);
        }

        [HttpGet("{id:int}", Name = "GetCategory")]
        public async Task<ActionResult<CategoryDTO>> Get(int id)
        {
            var category = await _categoryService.GetCategoryById(id);
            if (category == null) return NotFound("Category not found");

            return Ok(category);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CategoryDTO categoryDTO)
        {
            if (categoryDTO == null) return BadRequest("Invalid data");

            await _categoryService.Add(categoryDTO);

            return new CreatedAtRouteResult("GetCategory", new { id = categoryDTO.Id }, categoryDTO);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id, [FromBody] CategoryDTO categoryDTO)
        {
            if (categoryDTO == null) return BadRequest("Invalid data");

            if (id != categoryDTO.Id) return BadRequest();

            await _categoryService.Update(categoryDTO);

            return Ok(categoryDTO);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<CategoryDTO>> Delete(int id)
        {
            var category = await _categoryService.GetCategoryById(id);

            if (category == null) return NotFound("Category not found");

            await _categoryService.Remove(id);

            return Ok(category);
        }
    }
}