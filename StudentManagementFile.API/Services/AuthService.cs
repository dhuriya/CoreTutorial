using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using StudentManagementFile.API.Models;
using StudentManagementFile.API.Models.DTOs;

namespace StudentManagementFile.API.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUserService _userService;
        private readonly IConfiguration _config;

        public AuthService(IUserService userService, IConfiguration config)
        {
            _userService = userService;
            _config = config;
        }
        public AuthResponse? Login(LoginRequest request)
        {
            // 1. User dhoondein
            var user = _userService.GetByUsername(request.Username);
            if (user == null) return null;

            // 2. Password verify karein
            bool isPasswordValid = BCrypt.Net.BCrypt.Verify(request.Password, user.PasswordHash);
            if (!isPasswordValid) return null;

            // 3. Token generate karke return karein
            return GenerateAuthResponse(user);
        }

        public AuthResponse? Register(RegisterRequest request)
        {
            // 1. Check karein user pehle se hai ya nahi
            if (_userService.UserExists(request.Username, request.Email))
                return null; // Controller isko 400 Bad Request mein convert karega

            // 2. Password Hash karein (BCrypt)
            string passwordHash = BCrypt.Net.BCrypt.HashPassword(request.Password);

            // 3. Naya User banayein
            var user = new User
            {
                Username = request.Username,
                Email = request.Email,
                PasswordHash = passwordHash,
                Role = "User" // Default role
            };

            // 4. Save karein
            _userService.Add(user);

            // 5. Token generate karke return karein
            return GenerateAuthResponse(user);
        }
        private AuthResponse GenerateAuthResponse(User user)
        {
            var jwtSettings = _config.GetSection("Jwt");
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings["Key"]!));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var expiresAt = DateTime.UtcNow.AddMinutes(double.Parse(jwtSettings["ExpiryInMinutes"]!));

            // Claims (Token ke andar ka data)
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Username),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim(ClaimTypes.Role, user.Role),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var token = new JwtSecurityToken(
                issuer: jwtSettings["Issuer"],
                audience: jwtSettings["Audience"],
                claims: claims,
                expires: expiresAt,
                signingCredentials: creds
            );

            return new AuthResponse
            {
                Token = new JwtSecurityTokenHandler().WriteToken(token),
                Username = user.Username,
                Email = user.Email,
                Role = user.Role,
                ExpiresAt = expiresAt
            };
        }
    }
}