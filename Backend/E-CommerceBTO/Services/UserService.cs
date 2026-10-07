using E_CommerceDTO.DTO;
using E_CommerceDTO.DTO.UserDTO_s;
using E_CommerceDTO.models;
using E_CommerceDTO.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace E_CommerceBTO.Services
{
    public class UserService
    {
        private readonly UserRepository _repo;
        public UserService(UserRepository repo)
        {
            _repo = repo;
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
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(userregisterDTO.PasswordHash),
                Role = userregisterDTO.Role
            };
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
    }
}
 