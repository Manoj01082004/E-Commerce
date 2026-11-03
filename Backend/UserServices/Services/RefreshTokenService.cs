using UserServices.Models;
using UserServices.Repositories.Interfaces;
using System.Security.Cryptography;
using System.Text;

namespace UserServices.Services
{
    public class RefreshTokenService
    {
        private readonly IUserRepository _userRepository;

        public RefreshTokenService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<string> CreateRefreshTokenAsync(int userId)
        {
            var rawToken = Convert.ToBase64String(
                RandomNumberGenerator.GetBytes(64));

            var refreshToken = new RefreshToken
            {
                UserId = userId,
                TokenHash = HashToken(rawToken),
                ExpiresAt = DateTime.UtcNow.AddDays(7)
            };

            await _userRepository.CreateRefreshTokenAsync(refreshToken);

            return rawToken;
        }

        public async Task<User?> ValidateAndRotateRefreshTokenAsync(
            string rawToken)
        {
            var tokenHash = HashToken(rawToken);

            var refreshToken = await _userRepository
                .GetRefreshTokenByHashAsync(tokenHash);

            if (refreshToken is null ||
                refreshToken.User is null ||
                refreshToken.RevokedAt is not null ||
                refreshToken.ExpiresAt <= DateTime.UtcNow)
            {
                return null;
            }

            refreshToken.RevokedAt = DateTime.UtcNow;

            await _userRepository.UpdateRefreshTokenAsync(refreshToken);

            return refreshToken.User;
        }

        public async Task RevokeRefreshTokenAsync(string rawToken)
        {
            var tokenHash = HashToken(rawToken);

            var refreshToken = await _userRepository
                .GetRefreshTokenByHashAsync(tokenHash);

            if (refreshToken is null || refreshToken.RevokedAt is not null)
            {
                return;
            }

            refreshToken.RevokedAt = DateTime.UtcNow;

            await _userRepository.UpdateRefreshTokenAsync(refreshToken);
        }

        private static string HashToken(string token)
        {
            var tokenBytes = Encoding.UTF8.GetBytes(token);
            var hashBytes = SHA256.HashData(tokenBytes);

            return Convert.ToBase64String(hashBytes);
        }
    }
}