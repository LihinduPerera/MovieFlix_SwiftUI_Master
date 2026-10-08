using MovieFlix.Api.DTOs.Favorites;

namespace MovieFlix.Api.Services
{
    public interface IFavoriteService
    {
        Task<List<FavoriteMovieResponse>> GetUserFavoritesAsync(int userId);
        Task<FavoriteMovieResponse?> AddFavoriteAsync(int userId, int movieId);
        //Task<bool> RemoveFavoriteAsync(int userId, int movieId);
    }
}
