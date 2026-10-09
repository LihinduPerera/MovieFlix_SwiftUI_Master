using MovieFlix.Api.DTOs.Tmdb;

namespace MovieFlix.Api.Services
{
    public interface ITmdbService
    {
        Task<TmdbMovieSearchResponse> SearchMoviesAsync(
            string query, int page, CancellationToken cancellationToken = default);
    }
}
