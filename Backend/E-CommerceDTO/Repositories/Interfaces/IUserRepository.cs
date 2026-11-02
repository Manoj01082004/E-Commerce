using E_CommerceDTO.models;

namespace E_CommerceDTO.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<User?> GetUserByIdAsync(int id);
        Task<User?> GetUserByEmailAsync(string email);
        Task RegisterUserAsync(User user);
        Task CreateRefreshTokenAsync(RefreshToken refreshToken);
        Task<RefreshToken?> GetRefreshTokenByHashAsync(string tokenHash);
        Task UpdateRefreshTokenAsync(RefreshToken refreshToken);
    }
}
