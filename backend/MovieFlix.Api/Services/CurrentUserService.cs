using System.Security.Claims;

namespace MovieFlix.Api.Services
{
    public class CurrentUserService : ICurrentUserService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CurrentUserService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public int UserId
        {
            get
            {
                var userIdClaim = _httpContextAccessor
                    .HttpContext?
                    .User
                    .FindFirstValue(ClaimTypes.NameIdentifier);

                if (!int.TryParse(userIdClaim, out var userId))
                {
                    throw new UnauthorizedAccessException("Authenticated user ID is missing.");
                }

                return userId;
            }
        }

        public string Email
        {
            get
            {
                var emailClaim = _httpContextAccessor
                    .HttpContext?
                    .User
                    .FindFirstValue(ClaimTypes.Email);

                if (string.IsNullOrWhiteSpace(emailClaim))
                {
                    throw new UnauthorizedAccessException("Authenticated user email is missing.");
                }

                return emailClaim;
            }
        }
    }
}
