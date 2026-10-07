using MovieFlix.Api.DTOs.Movies;
using MovieFlix.Api.Models;

namespace MovieFlix.Api.Services
{
    public interface IMovieService
    {
        Task<List<Movie>> GetMoviesAsync();

        Task<Movie?> GetMovieByIdAsync(int id);

        Task<Movie> CreateMovieAsync(CreateMovieRequest request);
    }
}
