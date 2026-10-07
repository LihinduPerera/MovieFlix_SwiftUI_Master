using MovieFlix.Api.DTOs.Movies;
using MovieFlix.Api.Models;

namespace MovieFlix.Api.Services
{
    public interface IMovieService
    {
        Task<List<MovieResponse>> GetMoviesAsync();

        Task<MovieResponse> GetMovieByIdAsync(int id);

        Task<MovieResponse> CreateMovieAsync(CreateMovieRequest request);
    }
}
