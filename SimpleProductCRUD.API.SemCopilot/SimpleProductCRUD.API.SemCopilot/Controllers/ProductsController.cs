using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SimpleProductCRUD.API.SemCopilot.DTOs;
using SimpleProductCRUD.API.SemCopilot.Interfaces;

namespace SimpleProductCRUD.API.SemCopilot.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDTO>>> Get()
        {
            var products = await _productService.GetProducts();

            if (products == null) return NotFound("Products not found");

            return Ok(products);
        }

        [HttpGet("{id:int}", Name = "GetProduct")]
        public async Task<ActionResult<ProductDTO>> Get(int id)
        {
            var productDTO = await _productService.GetById(id);

            if (productDTO == null) return NotFound("Product not found");

            return Ok(productDTO);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] ProductDTO productDTO)
        {
            if (productDTO == null) return BadRequest("Invalid data");


            await _productService.Add(productDTO);

            return new CreatedAtRouteResult("GetProduct", new { id = productDTO.Id }, productDTO);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id, [FromBody] ProductDTO productDTO)
        {
            if (productDTO == null) return BadRequest("Invalid data");

            if (id != productDTO.Id) return BadRequest("Invalid data");

            await _productService.Update(productDTO);

            return Ok(productDTO);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<ProductDTO>> Delete(int id)
        {
            var productDTO = await _productService.GetById(id);
            if (productDTO == null) return NotFound("Product not found");

            await _productService.Remove(id);

            return Ok(productDTO);
        }
    }
}