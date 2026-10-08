using AutoMapper;
using E_CommerceBTO.Services;
using E_CommerceDTO.DTO.UserDTO_s;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace E_Commerce_Web.Controller
{
    [Route("api/users")]
    [ApiController]
    public class UserController:ControllerBase
    {
        private readonly UserService _service;
        private readonly IMapper _mapper;
        public UserController(UserService service, IMapper mapper)
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
        [HttpGet("me")]
        [Authorize]
        public async Task<ActionResult<UserDTO>> GetMyProfile()
        {
            try
            {
                var userId = GetCurrentUserId();
                var user = await _service.GetUserByIdAsync(userId);
                if (user == null)
                    return NotFound();

                var userDTO = _mapper.Map<UserDTO>(user);
                return Ok(userDTO);
            }
            catch (UnauthorizedAccessException ex)
            {
                return Unauthorized(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error {ex.Message}");
            }
        }
        [HttpPost("register")]
        [AllowAnonymous]
        public async Task<ActionResult<UserDTO>> RegisterUser([FromBody] UserRegisterDTO userRegisterDTO)
        {
            if (userRegisterDTO == null)
                return BadRequest("User data is null");
            var user = await _service.RegisterAsync(userRegisterDTO);
            if (user == null)
                return Conflict("Email already exists");
            var userDTO = _mapper.Map<UserDTO>(user);
            return CreatedAtAction(nameof(GetMyProfile), new { id = user.Id }, userDTO);
        }
        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<ActionResult<UserLoginResponseDTO>> LoginUser([FromBody] UserLoginDTO userLoginDTO)
        {
            if (userLoginDTO == null)
                return BadRequest("User data is null");
            try
            {
                var user = await _service.LoginUserAsync(userLoginDTO);
                if (user == null)
                    return Unauthorized("Invalid email or password");

                var token = _service.CreateToken(user);

                var response = new UserLoginResponseDTO
                {
                    Token = token,
                    User = _mapper.Map<UserDTO>(user)
                };
                return Ok(response);
            }
            catch (UnauthorizedAccessException ex)
            {
                return Unauthorized(ex.Message);
            }
        }
    }
}
