using AutoMapper;
using E_CommerceBTO.Services;
using E_CommerceDTO.DTO.CartItemDTO_s;
using E_CommerceDTO.models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace E_Commerce_Web.Controller
{
    [Authorize]
    [Route("api/CartItems")]
    [ApiController]
    public class CartItemController : ControllerBase
    {
        private readonly CartItemService _service;
        private readonly IMapper _mapper;
        public CartItemController(CartItemService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }
        private int GetCurrentUserId()
        {
            var userIdValue = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (!int.TryParse(userIdValue, out var userId))
            {
                throw new UnauthorizedAccessException("Invalid user token.");
            }

            return userId;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CartItemDTO>>> GetCartItemsByUserId()
        {
            try
            {
                var userId = GetCurrentUserId();
                var cartItems = await _service.GetCartItemsByUserIdAsync(userId);
                if (!cartItems.Any())
                {
                    return NotFound($"No cart items found for user ID {userId}.");
                }
                var cartItemDTOs = _mapper.Map<IEnumerable<CartItemDTO>>(cartItems);
                return Ok(cartItemDTOs);

            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
        [HttpGet("{id:int}")]
        public async Task<ActionResult<CartItemDTO>> GetCartItemById(int id)
        {
            try
            {
                if (id <= 0)
                {
                    return BadRequest("Invalid cart item ID.");
                }
                var cartItem = await _service.GetCartItemByIdAsync(id);
                if (cartItem == null)
                {
                    return NotFound($"Cart item not found for ID {id}.");
                }
                var cartItemDTO = _mapper.Map<CartItemDTO>(cartItem);
                return Ok(cartItemDTO);
            }
            catch (UnauthorizedAccessException ex)
            {
                return Unauthorized(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
        [HttpPost]
        public async Task<ActionResult<CartItemDTO>> AddCartItem([FromBody] CartItemCreateDTO cartItemCreateDTO)
        {
            try
            {
                if (cartItemCreateDTO == null)
                {
                    return BadRequest("Invalid cart item data.");
                }
                var userId = GetCurrentUserId();
                var cartItem = new CartItem
                {
                    UserId =userId,
                    ProductId=cartItemCreateDTO.ProductId,
                    Quantity=cartItemCreateDTO.Quantity
                };

                var savedCartItem = await _service.AddCartItemAsync(cartItem);

                var cartItemWithProduct = await _service.GetCartItemByIdAsync(savedCartItem.Id);

                var cartItemDTO = _mapper.Map<CartItemDTO>(cartItemWithProduct);
                return Ok(cartItemDTO);
            }
            catch (UnauthorizedAccessException ex)
            {
                return Unauthorized(ex.Message);
            }
        }
        [HttpPut("{id:int}")]
        public async Task<ActionResult<CartItemDTO>> UpdateCartItem(int id, [FromBody] CartItemUpdateDTO cartItemUpdateDTO)
        {
            try
            {
                if (id <= 0)
                {
                    return BadRequest("Invalid cart item ID.");
                }
                if (cartItemUpdateDTO == null)
                {
                    return BadRequest("Invalid cart item data.");
                }
                var cartItem = await _service.GetCartItemByIdAsync(id);
                if (cartItem == null)
                {
                    return NotFound($"Cart item not found for ID {id}.");
                }
                _mapper.Map(cartItemUpdateDTO, cartItem);
                cartItem.UpdatedAt = DateTime.UtcNow;
                await _service.UpdateCartItemAsync(cartItem);
                var updatedCartItemDTO = _mapper.Map<CartItemDTO>(cartItem);
                return Ok(updatedCartItemDTO);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> DeleteCartItem(int id)
        {
            try
            {
                if (id <= 0)
                {
                    return BadRequest("Invalid cart item ID.");
                }
                if (!await _service.DeleteCartItemAsync(id))
                {
                    return NotFound($"Cart item not found for ID {id}.");
                }
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
        [HttpDelete("clearItems")]
        public async Task<ActionResult> ClearCartItems()
        {
            try
            {

                var userId = GetCurrentUserId();
                if (!await _service.ClearCartItemAsync(userId))
                {
                    return NotFound($"No cart items found for user ID {userId}.");
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
