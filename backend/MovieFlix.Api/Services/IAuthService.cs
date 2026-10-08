using MovieFlix.Api.DTOs.Auth;

namespace MovieFlix.Api.Services
{
    public interface IAuthService
    {
        Task RegisterAsync(RegisterRequest request);
    }
}
