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

        public AuthService(MovieFlixDbContext context, IPasswordHasher<User> passwordHasher)
        {
            _context = context;
            _passwordHasher = passwordHasher;
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
    }
}
