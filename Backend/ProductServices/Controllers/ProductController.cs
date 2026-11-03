using AutoMapper;
using ProductServices.DTO.ProductDTO_s;
using ProductServices.Models;
using ProductServices.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ProductServices.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductController:ControllerBase
    {
        private readonly ProductService _service;
        private readonly IMapper _mapper;
        public ProductController(ProductService service,IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<ActionResult<ICollection<ProductDTO>>> GetAllProducts()
        {
            try
            {
                 var product= await _service.GetAllProductsAsync();
                 var productDTOs = _mapper.Map<ICollection<ProductDTO>>(product);
                 return Ok(productDTOs);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
        [HttpGet("{id:int}")]
        public async Task<ActionResult<ProductDTO>> GetProductById(int id)
        {
            try
            {
                var product = await _service.GetProductByIdAsync(id);
                if (product == null)
                {
                    return NotFound("Product not found");
                }
                var productDTO = _mapper.Map<ProductDTO>(product);
                return Ok(productDTO);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
        [HttpPost]
        [Authorize(Roles="Admin")]
        public async Task<ActionResult<ProductDTO>> CreateProduct([FromBody] ProductCreateDTO productCreateDTO)
        {
            try
            {
                if (productCreateDTO == null)
                {
                    return BadRequest("Product data is null");
                }
                var product = _mapper.Map<Product>(productCreateDTO);
                await _service.CreateProductAsync(product);

                var productDTO = _mapper.Map<ProductDTO>(product);

                return CreatedAtAction(nameof(GetProductById), new { id = product.ProductId }, productDTO);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
        [HttpPut("{id:int}")]
        [Authorize(Roles = "Admin")]

        public async Task<ActionResult<ProductDTO>> UpdateProduct(int id, [FromBody] ProductUpdateDTO productUpdateDTO)
        {
            try
            {
                if (productUpdateDTO == null)
                {
                    return BadRequest("Product data is null");
                }
                var existingProduct = await _service.GetProductByIdAsync(id);
                if (existingProduct == null)
                {
                    return NotFound("Product not found");
                }
                _mapper.Map(productUpdateDTO, existingProduct);
                existingProduct.UpdatedAt= DateTime.Now;
                await _service.UpdateProductAsync(existingProduct);
                return Ok(_mapper.Map<ProductDTO>(existingProduct));
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
        [HttpDelete("{id:int}")]
        [Authorize(Roles = "Admin")]

        public async Task<ActionResult<object>> DeleteProduct(int id)
        {
            try
            {
                if (id <= 0)
                {
                    return BadRequest("Invalid details");
                }
                if (!await _service.DeleteProductAsync(id))
                {
                    return NotFound("Product not found");
                }
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
