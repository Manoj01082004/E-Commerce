using AutoMapper;
using E_CommerceBTO.Services;
using E_CommerceDTO.DTO.CategoryDTO_s;
using E_CommerceDTO.models;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce_Web.Controller
{
    [Route("api/categories")]
    [ApiController]
    public class CategoryController:ControllerBase
    {
        private readonly CategoryService _service;
        private readonly IMapper _mapper;
        public CategoryController(CategoryService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<ActionResult<ICollection<CategoryDTO>>> GetAllCategories()
        {
            try
            {
                var categories = await _service.GetAllCategoriesAsync();
                var categoryDTOs = _mapper.Map<ICollection<CategoryDTO>>(categories);
                return Ok(categoryDTOs);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
        [HttpGet("{id:int}")]
        public async Task<ActionResult<CategoryDTO>> GetCategoryById(int id)
        {
            try
            {
                var category = await _service.GetCategoryByIdAsync(id);
                if (category == null)
                {
                    return NotFound("Category not found");
                }
                var categoryDTO = _mapper.Map<CategoryDTO>(category);
                return Ok(categoryDTO);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
        [HttpPost]
        public async Task<ActionResult<CategoryDTO>> CreateCategory([FromBody] CategoryCreateAndUpdateDTO categoryCreateAndUpdateDTO)
        {
            try
            {
                if (categoryCreateAndUpdateDTO == null)
                {
                    return BadRequest("Category data is null");
                }
                var category = _mapper.Map<Category>(categoryCreateAndUpdateDTO);
                await _service.CreateCategoryAsync(category);

                var categoryDTO = _mapper.Map<CategoryDTO>(category );

                return CreatedAtAction(nameof(GetCategoryById), new { id = category.Id }, categoryDTO);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
        [HttpPut("{id:int}")]
        public async Task<ActionResult<CategoryDTO>> UpdateCategory(int id, [FromBody] CategoryCreateAndUpdateDTO categoryCreateAndUpdateDTO)
        {
            try
            {
                if (categoryCreateAndUpdateDTO == null)
                {
                    return BadRequest("Category data is null");
                }
                var existingCategory = await _service.GetCategoryByIdAsync(id);
                if (existingCategory == null)
                {
                    return NotFound("Category not found");
                }
                _mapper.Map(categoryCreateAndUpdateDTO, existingCategory);
                existingCategory.UpdatedAt = DateTime.Now;
                await _service.UpdateCategoryAsync(existingCategory);
                return Ok(_mapper.Map<CategoryDTO>(existingCategory));
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
        [HttpDelete("{id:int}")]
        public async Task<ActionResult<object>> DeleteCategory(int id)
        {
            try
            {
                if (id <= 0)
                {
                    return BadRequest("Invalid details");
                }
                if (!await _service.DeleteCategoryAsync(id))
                {
                    return NotFound("Category not found");
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
