using Microsoft.AspNetCore.Identity;
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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Movie>()
                .HasIndex(movie => movie.TmdbId)
                .IsUnique(); //Both Performance and Data intergrity
        }
    }
}
