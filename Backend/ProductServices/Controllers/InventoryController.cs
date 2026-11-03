using AutoMapper;
using ProductServices.DTO.InventoryDTO_s;
using ProductServices.DTO.ProductDTO_s;
using ProductServices.Models;
using ProductServices.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ProductServices.Controllers
{
    [Authorize(Roles = "Admin")]
    [Route("api/inventory")]
    [ApiController]
    public class InventoryController:ControllerBase
    {
        private readonly InventoryService _service;
        private readonly IMapper _mapper;
        public InventoryController(InventoryService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<ActionResult<ICollection<InventoryDTO>>> GetAllInventory()
        {
            try
            {
                var inventory = await _service.GetAllInventoriesAsync();
                var inventoryDTOs = _mapper.Map<ICollection<InventoryDTO>>(inventory);
                return Ok(inventoryDTOs);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
        [HttpGet("{id:int}")]
        public async Task<ActionResult<InventoryDTO>> GetInventoryById(int id)
        {
            try
            {
                var inventory = await _service.GetInventoryByIdAsync(id);
                if (inventory == null)
                {
                    return NotFound("Inventory not found");
                }
                var inventoryDTO = _mapper.Map<InventoryDTO>(inventory);
                return Ok(inventoryDTO);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
        [HttpGet("product/{productId:int}")]
        public async Task<ActionResult<InventoryDTO>> GetInventoryByProductId(int productId)
        {
            try
            {
                var inventory = await _service.GetInventoryByProductIdAsync(productId);
                if (inventory == null)
                {
                    return NotFound("Inventory not found");
                }
                var inventoryDTO = _mapper.Map<InventoryDTO>(inventory);
                return Ok(inventoryDTO);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }   
        [HttpPost]
        public async Task<ActionResult<InventoryDTO>> CreateInventory([FromBody] InventoryCreateDTO inventoryCreateDTO)
        {
            try
            {
                if (inventoryCreateDTO == null)
                {
                    return BadRequest("Inventory data is null");
                }
                var inventory = _mapper.Map<Inventory>(inventoryCreateDTO);
                await _service.CreateInventoryAsync(inventory);

                var inventoryDTO = _mapper.Map<InventoryDTO>(inventory);

                return CreatedAtAction(nameof(GetInventoryById), new { id = inventory.Id }, inventoryDTO);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
        [HttpPut("{id:int}")]
        public async Task<ActionResult<InventoryDTO>> UpdateInventory(int id, [FromBody] InventoryUpdateDTO inventoryUpdateDTO)
        {
            try
            {
                if (inventoryUpdateDTO == null)
                {
                    return BadRequest("Inventory data is null");
                }
                var existingInventory = await _service.GetInventoryByIdAsync(id);
                if (existingInventory == null)
                {
                    return NotFound("Inventory not found");
                }
                _mapper.Map(inventoryUpdateDTO, existingInventory);
                existingInventory.UpdatedAt = DateTime.Now;
                await _service.UpdateInventoryAsync(existingInventory);
                return Ok(_mapper.Map<InventoryDTO>(existingInventory));
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
        [HttpPatch("{id:int}/restock")]
        public async Task<ActionResult<InventoryDTO>> RestockInventory(int id, [FromBody] RestockInventoryDTO restockInventoryDTO)
        {
            try
            {
                if (restockInventoryDTO == null || restockInventoryDTO.QuantityToAdd <= 0 || id <= 0)
                {
                    return BadRequest("Quantity or ID must be greater than zero");
                }
                var existingInventory = await _service.GetInventoryByIdAsync(id);
                if (existingInventory == null)
                {
                    return NotFound("Inventory not found");
                }
                await _service.RestockInventoryAsync(id, restockInventoryDTO.QuantityToAdd);
                return Ok(_mapper.Map<InventoryDTO>(existingInventory) );
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
        [HttpDelete("{id:int}")]
        public async Task<ActionResult<object>> DeleteInventory(int id)
        {
            try
            {
                if (id <= 0)
                {
                    return BadRequest("Invalid details");
                }
                if (!await _service.DeleteInventoryAsync(id))
                {
                    return NotFound("Inventory not found");
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
