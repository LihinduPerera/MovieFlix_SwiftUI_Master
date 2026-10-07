using MovieFlix.Api.DTOs.Common;
using MovieFlix.Api.DTOs.Movies;

namespace MovieFlix.Api.Services
{
    public interface IMovieService
    {
        Task<PagedResponse<MovieResponse>> GetMoviesAsync(int page, int pageSize);

        Task<MovieResponse?> GetMovieByIdAsync(int id);

        Task<MovieResponse> CreateMovieAsync(CreateMovieRequest request);

        Task<MovieResponse?> UpdateMovieAsync(int id, UpdateMovieRequest request);

        Task<bool> DeleteMovieAsync(int id);
    }
}