using Microsoft.EntityFrameworkCore;
using MovieFlix.Api.Data;
using MovieFlix.Api.Models;

namespace MovieFlix.Api.Services;

public class MovieService : IMovieService
{
    private readonly MovieFlixDbContext _context;

    public MovieService(MovieFlixDbContext context)
    {
        _context = context;
    }

    public async Task<List<Movie>> GetMoviesAsync()
    {
        return await _context.Movies
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<Movie?> GetMovieByIdAsync(int id)
    {
        return await _context.Movies
            .AsNoTracking()
            .FirstOrDefaultAsync(movie => movie.Id == id);
    }
}