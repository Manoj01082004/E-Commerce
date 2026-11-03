using UserServices.DTOs;
using UserServices.Models;
using UserServices.Repositories.Interfaces;

namespace UserServices.Services
{
    public class UserService
    {
        private readonly IUserRepository _repo;
        private readonly JWTTokenService _jwtTokenService;
        public UserService(IUserRepository repo, JWTTokenService jwtTokenService)
        {
            _repo = repo;
            _jwtTokenService = jwtTokenService;
        }
        public async Task<User?> GetUserByIdAsync(int id)
        {
            return await _repo.GetUserByIdAsync(id);
        }
        public async Task<User?> RegisterAsync(UserRegisterDTO userregisterDTO)
        {
            var existingUser = await _repo.GetUserByEmailAsync(userregisterDTO.Email);
            if (existingUser != null)
            {
                return null; 
            }
            var user = new User
            {
                Name = userregisterDTO.Name,
                Email = userregisterDTO.Email,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(userregisterDTO.PasswordHash)            };
            await _repo.RegisterUserAsync(user);
            return user;
        }
        public async Task<User?> LoginUserAsync(UserLoginDTO userLoginDTO)
        {
            var user = await _repo.GetUserByEmailAsync(userLoginDTO.Email);
            if (user == null)
                return null;

            if (!BCrypt.Net.BCrypt.Verify(userLoginDTO.PasswordHash, user.PasswordHash))
            {
                throw new UnauthorizedAccessException("Invalid email or password.");
            }
            return user;
        }
        public string CreateToken(User user)
        {
             return _jwtTokenService.CreateToken(user);
        }
        public string CreateAccessToken(User user)
        {
            return _jwtTokenService.CreateToken(user);
        }
    }
}
 