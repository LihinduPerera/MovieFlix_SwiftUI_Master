using Microsoft.EntityFrameworkCore;
using MovieFlix.Api.Models;

namespace MovieFlix.Api.Data
{
    public class MovieFlixDbContext : DbContext
    {
        public MovieFlixDbContext(DbContextOptions<MovieFlixDbContext> options) : base (options)
        {

        }

        public DbSet<Movie> Movies => Set<Movie>();
    }
}
