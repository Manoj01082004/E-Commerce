using OrderServices.DTO_s.CartItemDTO_s;
using OrderServices.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OrderServices.Services;
using System.Security.Claims;

namespace OrderServices.Controllers
{
    [Authorize]
    [Route("api/cartitems")]
    [ApiController]
    public class CartItemController : ControllerBase
    {
        private readonly CartItemService _service;

        public CartItemController(CartItemService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CartItemDTO>>> GetMyCart()
        {
            try
            {
                var userId = GetCurrentUserId();

                var cartItems = await _service
                    .GetCartItemsByUserIdAsync(userId);

                return Ok(cartItems);
            }
            catch (UnauthorizedAccessException ex)
            {
                return Unauthorized(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(
                    500,
                    $"Internal server error: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<ActionResult<CartItemDTO>> AddCartItem(
            [FromBody] CartItemCreateDTO cartItemCreateDTO)
        {
            Console.WriteLine("Hi...");
            try
            {
                if (cartItemCreateDTO is null)
                {
                    return BadRequest("Cart item data is required.");
                }

                var userId = GetCurrentUserId();

                var cartItem = new CartItem
                {
                    UserId = userId,
                    ProductId = cartItemCreateDTO.ProductId,
                    Quantity = cartItemCreateDTO.Quantity
                };

                var savedCartItem = await _service
                    .AddCartItemAsync(cartItem);

                if (savedCartItem is null)
                {
                    return NotFound("Product is not available.");
                }

                return Ok(savedCartItem);
            }
            catch (UnauthorizedAccessException ex)
            {
                return Unauthorized(ex.Message);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(
                    500,
                    $"Internal server error: {ex.Message}");
            }
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> UpdateCartItem(
            int id,
            [FromBody] CartItemUpdateDTO cartItemUpdateDTO)
        {
            try
            {
                if (id <= 0)
                {
                    return BadRequest("Invalid cart item ID.");
                }

                if (cartItemUpdateDTO is null)
                {
                    return BadRequest("Cart item data is required.");
                }

                var userId = GetCurrentUserId();

                var updated = await _service.UpdateCartItemAsync(
                    userId,
                    id,
                    cartItemUpdateDTO.Quantity);

                if (!updated)
                {
                    return NotFound("Cart item not found.");
                }

                return Ok(new
                {
                    Message = "Cart item updated successfully."
                });
            }
            catch (UnauthorizedAccessException ex)
            {
                return Unauthorized(ex.Message);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(
                    500,
                    $"Internal server error: {ex.Message}");
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

                var userId = GetCurrentUserId();

                var deleted = await _service.DeleteCartItemAsync(
                    userId,
                    id);

                if (!deleted)
                {
                    return NotFound("Cart item not found.");
                }

                return NoContent();
            }
            catch (UnauthorizedAccessException ex)
            {
                return Unauthorized(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(
                    500,
                    $"Internal server error: {ex.Message}");
            }
        }

        [HttpDelete("clear")]
        public async Task<ActionResult> ClearMyCart()
        {
            try
            {
                var userId = GetCurrentUserId();

                var cleared = await _service.ClearCartItemAsync(userId);

                if (!cleared)
                {
                    return NotFound("Cart is empty.");
                }

                return NoContent();
            }
            catch (UnauthorizedAccessException ex)
            {
                return Unauthorized(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(
                    500,
                    $"Internal server error: {ex.Message}");
            }
        }

        private int GetCurrentUserId()
        {
            var userIdValue = User.FindFirstValue(
                ClaimTypes.NameIdentifier);

            if (!int.TryParse(userIdValue, out var userId))
            {
                throw new UnauthorizedAccessException(
                    "Invalid user token.");
            }

            return userId;
        }
    }
}