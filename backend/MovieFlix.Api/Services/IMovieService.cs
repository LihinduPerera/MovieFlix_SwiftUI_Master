using MovieFlix.Api.Models;

namespace MovieFlix.Api.Services
{
    public interface IMovieService
    {
        Task<List<Movie>> GetMoviesAsync();

        Task<Movie?> GetMovieByIdAsync(int id);
    }
}
