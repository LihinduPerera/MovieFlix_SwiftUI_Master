using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MovieFlix.Api.Data;
using MovieFlix.Api.DTOs.Auth;
using MovieFlix.Api.Exceptions;
using MovieFlix.Api.Models;

namespace MovieFlix.Api.Services
{
    public class AuthService : IAuthService
    {
        private readonly MovieFlixDbContext _context;
        private readonly IPasswordHasher<User> _passwordHasher;
        private readonly IJwtService _jwtService;

        public AuthService(MovieFlixDbContext context, 
            IPasswordHasher<User> passwordHasher,
            IJwtService jWTService)
        {
            _context = context;
            _passwordHasher = passwordHasher;
            _jwtService = jWTService;
        }

        public async Task RegisterAsync(RegisterRequest request)
        {
            var email = request.Email.ToLowerInvariant();

            var emailExists = await _context.Users.AnyAsync(
                user => user.Email == email);

            if (emailExists)
            {
                throw new UserAlreadyExistsException(email);
            }

            var user = new User
            {
                Email = email,
                DisplayName = request.DisplayName.Trim(),
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

            user.PasswordHash = _passwordHasher.HashPassword(user, request.Password);

            _context.Users.Add(user);

            await _context.SaveChangesAsync();
        }

        public async Task<LoginResponse?> LoginAsync(LoginRequest request)
        {
            var email = request.Email
                .Trim()
                .ToLowerInvariant();

            var user = await _context.Users
                .FirstOrDefaultAsync(user =>
                user.Email == email);

            if (user is null)
            {
                return null;
            }

            var passwordResult = _passwordHasher.VerifyHashedPassword(
                user,
                user.PasswordHash,
                request.Password);

            if(passwordResult == PasswordVerificationResult.Failed)
            {
                return null;
            }

            var token = _jwtService.GenerateToken(user.Id, user.Email);

            return new LoginResponse
            {
                AccessToken = token,
            };
        }
    }
}
