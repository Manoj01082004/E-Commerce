using AutoMapper;
using E_CommerceBTO.Services;
using E_CommerceDTO.DTO.PaymentDTO_s;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace E_Commerce_Web.Controller
{
    [Authorize]
    [Route("api/payments")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly PaymentService _service;
        private readonly IMapper _mapper;

        public PaymentController(PaymentService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<PaymentDTO>> GetPaymentById(int id)
        {
            try
            {
                if (id <= 0)
                {
                    return BadRequest("Invalid payment ID.");
                }

                var userId = GetCurrentUserId();

                var payment = await _service.GetPaymentByIdAsync(id);

                if (payment is null)
                {
                    return NotFound("Payment not found.");
                }

                if (payment.Order is null || payment.Order.UserId != userId)
                {
                    return Forbid();
                }

                return Ok(_mapper.Map<PaymentDTO>(payment));
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
        public async Task<ActionResult<PaymentDTO>> CreatePayment([FromBody] PaymentCreateDTO paymentCreateDTO)
        {
            try
            {
                if (paymentCreateDTO is null)
                {
                    return BadRequest("Payment data is null.");
                }

                var userId = GetCurrentUserId();

                var payment = await _service.CreatePaymentAsync(
                    userId,
                    paymentCreateDTO.OrderId,
                    paymentCreateDTO.PaymentMethod);

                if (payment is null)
                {
                    return NotFound("Order not found.");
                }

                var paymentDTO = _mapper.Map<PaymentDTO>(payment);

                return CreatedAtAction(
                    nameof(GetPaymentById),
                    new { id = payment.Id },
                    paymentDTO);
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

        [HttpPut("{id:int}/complete")]
        public async Task<ActionResult<PaymentDTO>> CompletePayment(int id,[FromBody] PaymentCompleteDTO paymentCompleteDTO)
        {
            try
            {
                if (id <= 0)
                {
                    return BadRequest("Invalid payment ID.");
                }

                if (paymentCompleteDTO is null)
                {
                    return BadRequest("Payment data is null.");
                }

                var userId = GetCurrentUserId();

                var payment = await _service.CompletePaymentAsync(
                    userId,
                    id,
                    paymentCompleteDTO.TransactionId);

                if (payment is null)
                {
                    return NotFound("Payment not found.");
                }

                return Ok(_mapper.Map<PaymentDTO>(payment));
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