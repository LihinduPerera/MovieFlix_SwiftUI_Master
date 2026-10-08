using Microsoft.EntityFrameworkCore;
using MovieFlix.Api.Data;
using MovieFlix.Api.DTOs.Favorites;
using MovieFlix.Api.Exceptions;
using MovieFlix.Api.Models;

namespace MovieFlix.Api.Services
{
    public class FavoriteService : IFavoriteService
    {
        private readonly MovieFlixDbContext _context;

        public FavoriteService(MovieFlixDbContext context)
        {
            _context = context;
        }

        public async Task<List<FavoriteMovieResponse>> GetUserFavoritesAsync(int userId)
        {
            var favorites = await _context.Favorites
                .AsNoTracking()
                .Where(favorite => favorite.UserId == userId)
                //Include() — load the related entity , Select() — tell the database exactly what you need
                //We Use Select() because 'I don't need Favorite and Movie entities. I need these five pieces of data.'
                //That's called Projection!!!!
                .Select(favorite => new FavoriteMovieResponse
                {
                    Id = favorite.Id,
                    TmdbId = favorite.Movie.TmdbId,
                    Title = favorite.Movie.Title,
                    Overview = favorite.Movie.Overview,
                    FavoritedAt = favorite.CreatedAt
                })
                .ToListAsync();

            return favorites;
        }

        public async Task<FavoriteMovieResponse?> AddFavoriteAsync(int userId, int movieId)
        {
            var userExists = await _context.Users
                .AsNoTracking()
                .AnyAsync(user => user.Id == userId);

            if (!userExists)
            {
                return null;
            }

            var movieExists = await _context.Movies
                .AsNoTracking()
                .AnyAsync(movie => movie.Id == movieId);

            if (!movieExists)
            {
                return null;
            }

            var existingFavorite = await _context.Favorites
                .AsNoTracking()
                .FirstOrDefaultAsync(favorite =>
                    favorite.UserId == userId &&
                    favorite.MovieId == movieId);

            if (existingFavorite is not null)
            {
                throw new FavoriteAlreadyExistsException(userId, movieId);
            }

            var favorite = new Favorite
            {
                UserId = userId,
                MovieId = movieId,
                CreatedAt = DateTime.UtcNow
            };

            _context.Favorites.Add(favorite);

            await _context.SaveChangesAsync();

            return await _context.Favorites
                .AsNoTracking()
                .Where(f => f.Id == favorite.Id)
                .Select(f => new FavoriteMovieResponse
                {
                    Id = f.Id,
                    TmdbId = f.Movie.TmdbId,
                    Title = f.Movie.Title,
                    Overview = f.Movie.Overview,
                    FavoritedAt = f.CreatedAt
                })
                .FirstAsync();
        }

        public async Task<bool> RemoveFavoriteAsync(int userId,int movieId)
        {
            var favorite = await _context.Favorites
                .FirstOrDefaultAsync(favorite =>
                    favorite.UserId == userId &&
                    favorite.MovieId == movieId);

            if (favorite is null)
            {
                return false;
            }

            _context.Favorites.Remove(favorite);

            await _context.SaveChangesAsync();

            return true;
        }
    }
}
