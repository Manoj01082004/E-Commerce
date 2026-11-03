using UserServices.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace UserServices.Services
{
    public class JWTTokenService
    {
        private readonly IConfiguration _configuration;
        public JWTTokenService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public string CreateToken(User user)
        {
            var key= _configuration["Jwt:Key"];
            var EncryptionKey = _configuration["Jwt:EncryptionKey"];
            var issuer = _configuration["Jwt:Issuer"];
            var audience = _configuration["Jwt:Audience"];
            if (string.IsNullOrWhiteSpace(key) || string.IsNullOrWhiteSpace(EncryptionKey) || string.IsNullOrWhiteSpace(issuer) || string.IsNullOrWhiteSpace(audience))
            {
                throw new InvalidOperationException("JWT configuration is missing or invalid.");
            }
            var claims=new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier,user.Id.ToString()),
                new Claim(ClaimTypes.Name,user.Name),
                new Claim(ClaimTypes.Email,user.Email),
                new Claim(ClaimTypes.Role, user.Role),
            };
            var signingKeyBytes = Encoding.UTF8.GetBytes(key);
            var encryptionKeyBytes = Encoding.UTF8.GetBytes(EncryptionKey);
            if (signingKeyBytes.Length < 32)
            {
                throw new InvalidOperationException("Jwt:Key must be at least 32 bytes long.");
            }
            if (encryptionKeyBytes.Length != 32)
            {
                throw new InvalidOperationException("Jwt:EncryptionKey must be exactly 32 bytes long when using Aes256KW.");
            }
            var securityKey = new SymmetricSecurityKey(signingKeyBytes);
            var securityEncryptionKey = new SymmetricSecurityKey(encryptionKeyBytes);
            var signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var encryptingCredentials = new EncryptingCredentials(securityEncryptionKey, SecurityAlgorithms.Aes256KW, SecurityAlgorithms.Aes256CbcHmacSha512);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddMinutes(15),
                SigningCredentials = signingCredentials,
                EncryptingCredentials = encryptingCredentials
            };
            tokenDescriptor.Issuer = issuer;
            tokenDescriptor.Audience = audience;
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}   
