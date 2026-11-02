using AutoMapper;
using E_CommerceBTO.Services;
using E_CommerceDTO.DTO.OrderDTO_s;
using E_CommerceDTO.models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace E_Commerce_Web.Controller
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly OrderService _service;
        private readonly IMapper _mapper;
        public OrderController(OrderService service, IMapper mapper)
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
        [Authorize(Roles=Roles.Admin)]
        public async Task<ActionResult<IEnumerable<OrderDTO>>> GetAllOrders()
        {
            try
            {
                var orders = await _service.GetAllOrdersAsync();
                if (!orders.Any())
                {
                    return NotFound("No orders found.");
                }
                var orderDTOs = orders.Select(o => _mapper.Map<OrderDTO>(o));
                return Ok(orderDTOs);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
        [HttpGet("{id:int}")]
        public async Task<ActionResult<OrderDTO>> GetOrderById(int id)
        {
            try
            {
                if (id <= 0)
                {
                    return BadRequest("Invalid order ID.");
                }
                var order = await _service.GetOrderByIdAsync(id);
                if (order == null)
                {
                    return NotFound("Order not found.");
                }
                var orderDTO = _mapper.Map<OrderDTO>(order);
                return Ok(orderDTO);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
        [HttpGet("my-orders")]
        public async Task<ActionResult<IEnumerable<OrderDTO>>> GetOrdersByUserId()
        {
            try
            {
                var userId = GetCurrentUserId();

                var orders = await _service.GetOrdersByUserIdAsync(userId);

                if (!orders.Any())
                {
                    return NotFound("No orders found for the specified user.");
                }

                var orderDTOs = orders.Select(order =>
                    _mapper.Map<OrderDTO>(order));

                return Ok(orderDTOs);
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
        [HttpPost("create-from-cart")]
        [Authorize]
        public async Task<ActionResult<OrderDTO>> CreateOrderFromCart([FromBody] CheckoutDTO checkoutDTO)
        {
            try
            {
                if (checkoutDTO is null)
                {
                    return BadRequest("Order data is null.");
                }
                var userId = GetCurrentUserId();

                var order = await _service.CreateOrderFromCartAsync(userId,checkoutDTO.ShippingAddress);

                if (order is null)
                {
                    return NotFound("User not found.");
                }

                var orderDTO = _mapper.Map<OrderDTO>(order);

                return CreatedAtAction(
                    nameof(GetOrderById),
                    new { id = order.Id },
                    orderDTO);
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
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> DeleteOrder(int id)
        {
            try
            {
                if (id <= 0)
                {
                    return BadRequest("Invalid order ID.");
                }
                if (!await _service.DeleteOrderAsync(id))
                {
                    return NotFound("Order not found.");
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
