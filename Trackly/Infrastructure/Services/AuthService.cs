using Trackly.Application.DTOs.Auth;
using Trackly.Application.Interfaces;
using Trackly.Domain.Entities;

namespace Trackly.Infrastructure.Services
{
    public class AuthService
    {
        private readonly IUserRepository _userRepository;
        private readonly TokenService _tokenService;

        public AuthService(IUserRepository userRepository, TokenService tokenService)
        {
            _userRepository = userRepository;
            _tokenService = tokenService;
        }

        public async Task Register(RegisterDto dto)
        {
            var existing = await _userRepository.GetByPhoneAsync(dto.Phone);

            if (existing != null)
            {
                throw new Exception("User already exists");
            }

            var hash = BCrypt.Net.BCrypt.HashPassword(dto.Password);

            var user = new User(
                dto.FirstName,
                dto.LastName,
                dto.BirthDate,
                dto.Phone,
                hash
            );

            await _userRepository.AddAsync(user);
            await _userRepository.SaveChangesAsync();
        }

        public async Task<AuthResponseDto?> Login(LoginDto dto)
        {
            var user = await _userRepository.GetByPhoneAsync(dto.Phone);

            if (user == null || !BCrypt.Net.BCrypt.Verify(dto.Password, user.PasswordHash))
            {
                return null;
            }

            var access = _tokenService.GenerateAccessToken(user);
            var refresh = _tokenService.GenerateRefreshToken();

            user.SetRefreshToken(refresh, DateTime.UtcNow.AddDays(7));

            await _userRepository.SaveChangesAsync();

            return new AuthResponseDto
            {
                AccessToken = access,
                RefreshToken = refresh,
            };
        }

        public async Task<AuthResponseDto> Refresh(string refreshToken)
        {
            var user = await _userRepository.GetByRefreshTokenAsync(refreshToken);

            if (user == null || user.RefreshTokenExpiry < DateTime.UtcNow)
            {
                throw new Exception("Invalid refresh token");
            }

            var newAccess = _tokenService.GenerateAccessToken(user);
            var newRefresh = _tokenService.GenerateRefreshToken();

            user.SetRefreshToken(newRefresh, DateTime.UtcNow.AddDays(7));

            await _userRepository.SaveChangesAsync();

            return new AuthResponseDto
            {
                AccessToken = newAccess,
                RefreshToken = newRefresh
            };
        }
    }
}
