using MovieFlix.Api.Models;

namespace MovieFlix.Api.Services
{
    public interface IMovieService
    {
        List<Movie> GetMovies();

        Movie? GetMovieById(int id);
    }
}
