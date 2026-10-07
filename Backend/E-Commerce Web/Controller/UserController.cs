using AutoMapper;
using E_CommerceBTO.Services;
using E_CommerceDTO.DTO.UserDTO_s;
using Microsoft.AspNetCore.Mvc;

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
        [HttpGet("{id:int}")]
        public async Task<ActionResult<UserDTO>> GetUserById(int id)
        {
            var user = await _service.GetUserByIdAsync(id);
            if (user == null)
                return NotFound();

            var userDTO = _mapper.Map<UserDTO>(user);
            return Ok(userDTO);
        }
        [HttpPost("register")]
        public async Task<ActionResult<UserDTO>> RegisterUser([FromBody] UserRegisterDTO userRegisterDTO)
        {
            if (userRegisterDTO == null)
                return BadRequest("User data is null");
            var user = await _service.RegisterAsync(userRegisterDTO);
            if (user == null)
                return Conflict("Email already exists");
            var userDTO = _mapper.Map<UserDTO>(user);
            return CreatedAtAction(nameof(GetUserById), new { id = user.Id }, userDTO);
        }
        [HttpPost("login")]
        public async Task<ActionResult<UserDTO>> LoginUser([FromBody] UserLoginDTO userLoginDTO)
        {
            if (userLoginDTO == null)
                return BadRequest("User data is null");
            try
            {
                var user = await _service.LoginUserAsync(userLoginDTO);
                if (user == null)
                    return Unauthorized("Invalid email or password");
                var userDTO = _mapper.Map<UserDTO>(user);
                return Ok(userDTO);
            }
            catch (UnauthorizedAccessException ex)
            {
                return Unauthorized(ex.Message);
            }
        }
    }
}
