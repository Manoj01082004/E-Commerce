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
        private readonly RefreshTokenService _refreshTokenService;
        private readonly IMapper _mapper;
        public UserController(UserService service, RefreshTokenService refreshTokenService, IMapper mapper)
        {
            _service = service;
            _refreshTokenService = refreshTokenService;
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
        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<ActionResult<UserDTO>> LoginUser([FromBody] UserLoginDTO userLoginDTO)
        {
            try
            {
                if (userLoginDTO is null)
                {
                    return BadRequest("User data is null.");
                }

                var user = await _service.LoginUserAsync(userLoginDTO);

                if (user is null)
                {
                    return Unauthorized("Invalid email or password.");
                }

                var accessToken = _service.CreateToken(user);

                var refreshToken = await _refreshTokenService
                    .CreateRefreshTokenAsync(user.Id);

                Response.Cookies.Append("access_token", accessToken, new CookieOptions
                {
                    HttpOnly = true,
                    Secure = true,
                    SameSite = SameSiteMode.None,
                    Expires = DateTimeOffset.UtcNow.AddMinutes(10)
                });

                Response.Cookies.Append("refresh_token", refreshToken, new CookieOptions
                {
                    HttpOnly = true,
                    Secure = true,
                    SameSite = SameSiteMode.None,
                    Expires = DateTimeOffset.UtcNow.AddDays(7)
                });

                return Ok(_mapper.Map<UserDTO>(user));
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
        [AllowAnonymous]
        [HttpPost("logout")]
        public async Task<IActionResult> LogoutUser()
        {
            var rawRefreshToken = Request.Cookies["refresh_token"];

            if (!string.IsNullOrWhiteSpace(rawRefreshToken))
            {
                await _refreshTokenService.RevokeRefreshTokenAsync(rawRefreshToken);
            }

            Response.Cookies.Delete("access_token", new CookieOptions
            {
                HttpOnly = true,
                Secure = true,
                SameSite = SameSiteMode.None
            });

            Response.Cookies.Delete("refresh_token", new CookieOptions
            {
                HttpOnly = true,
                Secure = true,
                SameSite = SameSiteMode.None
            });

            return Ok(new
            {
                Message = "Logged out successfully."
            });
        }
        [AllowAnonymous]
        [HttpPost("refresh")]
        public async Task<ActionResult<UserDTO>> RefreshToken()
        {
            try
            {
                var rawRefreshToken = Request.Cookies["refresh_token"];

                if (string.IsNullOrWhiteSpace(rawRefreshToken))
                {
                    return Unauthorized("Refresh token is missing.");
                }

                var user = await _refreshTokenService
                    .ValidateAndRotateRefreshTokenAsync(rawRefreshToken);

                if (user is null)
                {
                    return Unauthorized("Refresh token is invalid or expired.");
                }

                var accessToken = _service.CreateToken(user);

                var newRefreshToken = await _refreshTokenService
                    .CreateRefreshTokenAsync(user.Id);

                Response.Cookies.Append("access_token", accessToken, new CookieOptions
                {
                    HttpOnly = true,
                    Secure = true,
                    SameSite = SameSiteMode.None,
                    Expires = DateTimeOffset.UtcNow.AddMinutes(15)
                });

                Response.Cookies.Append("refresh_token", newRefreshToken, new CookieOptions
                {
                    HttpOnly = true,
                    Secure = true,
                    SameSite = SameSiteMode.None,
                    Expires = DateTimeOffset.UtcNow.AddDays(7)
                });

                return Ok(_mapper.Map<UserDTO>(user));
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
