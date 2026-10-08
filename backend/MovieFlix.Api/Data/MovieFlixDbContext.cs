using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MovieFlix.Api.Models;
using System.Data;

namespace MovieFlix.Api.Data
{
    public class MovieFlixDbContext : DbContext
    {
        public MovieFlixDbContext(DbContextOptions<MovieFlixDbContext> options) : base (options)
        {

        }

        public DbSet<Movie> Movies => Set<Movie>();
        public DbSet<User> Users => Set<User>();
        public DbSet<Favorite> Favorites => Set<Favorite>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Movie>()
                .HasIndex(movie => movie.TmdbId)
                .IsUnique(); //Both Performance and Data intergrity

            modelBuilder.Entity<Movie>()
                .HasIndex(movie => movie.Title);

            modelBuilder.Entity<Favorite>()
                .HasOne(favorite => favorite.User)
                .WithMany()
                .HasForeignKey(favorite => favorite.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Favorite>()
                .HasOne(favorite => favorite.Movie)
                .WithMany()
                .HasForeignKey(favorite => favorite.MovieId)
                .OnDelete(DeleteBehavior.Cascade);

            //composite unique constraint / index.
            modelBuilder.Entity<Favorite>()
                .HasIndex(favorite => new
                {
                    favorite.UserId,
                    favorite.MovieId
                })
                .IsUnique();

            modelBuilder.Entity<User>()
                .HasIndex(user => user.Email)
                .IsUnique();
        }
    }
}
