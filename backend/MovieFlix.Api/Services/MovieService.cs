using MovieFlix.Api.Models;

namespace MovieFlix.Api.Services
{
    public class MovieService
    {
        private readonly List<Movie> _movies = [
            new Movie {
                Id = 1,
                Title = "Interstellar",
                Overview = "A team of explorers travels through a wormhole in space."
            },
            new Movie {
                Id = 2,
                Title = "Inception",
                Overview = "A skilled thief enters people's dreams to steal information."
            },
            new Movie {
                Id = 3,
                Title = "The Dark Knight",
                Overview = "Batman faces a dangerous criminal who brings chaos to Gotham."
            }
        ];

        public List<Movie> GetMovies()
        {
            return _movies;
        }

        public Movie? getMovieById(int id)
        {
            return _movies.FirstOrDefault(movie => movie.Id == id);
        }
    }
}

