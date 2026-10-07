using AutoMapper;
using E_CommerceBTO.Services;
using E_CommerceDTO.DTO.OrderDTO_s;
using E_CommerceDTO.models;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce_Web.Controller
{
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
        [HttpGet]
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
        [HttpGet("user/{userId:int}")]
        public async Task<ActionResult<IEnumerable<OrderDTO>>> GetOrdersByUserId(int userId)
        {
            try
            {
                if (userId <= 0)
                {
                    return BadRequest("Invalid user ID.");
                }
                var orders = await _service.GetOrdersByUserIdAsync(userId);
                if (!orders.Any())
                {
                    return NotFound("No orders found for the specified user.");
                }
                var orderDTOs = orders.Select(o => _mapper.Map<OrderDTO>(o));
                return Ok(orderDTOs);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
        [HttpPost]
        public async Task<ActionResult> CreateOrder([FromBody] OrderCreateDTO orderCreateDTO)
        {
            try
            {
                if (orderCreateDTO == null)
                {
                    return BadRequest("Order data is null.");
                }
                var order = _mapper.Map<Order>(orderCreateDTO);
                await _service.CreateOrderAsync(order);
                var orderDTO = _mapper.Map<OrderDTO>(order);
                return CreatedAtAction(nameof(GetOrderById), new { id = order.Id }, orderDTO);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
        [HttpPut("{id:int}")]
        public async Task<ActionResult<OrderDTO>> UpdateOrder(int id,[FromBody] OrderUpdateDTO orderUpdateDTO)
        {
            try
            {
                if (id <= 0)
                {
                    return BadRequest("Invalid order ID.");
                }

                if (orderUpdateDTO is null)
                {
                    return BadRequest("Order data is null.");
                }

                var existingOrder = await _service.GetOrderByIdAsync(id);

                if (existingOrder is null)
                {
                    return NotFound("Order not found.");
                }

                _mapper.Map(orderUpdateDTO, existingOrder);

                await _service.UpdateOrderAsync(existingOrder);

                var orderDTO = _mapper.Map<OrderDTO>(existingOrder);

                return Ok(orderDTO);
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
