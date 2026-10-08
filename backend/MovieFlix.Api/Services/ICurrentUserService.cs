namespace MovieFlix.Api.Services
{
    public interface ICurrentUserService
    {
        int UserId { get; }
        string Email { get; }
    }
}
