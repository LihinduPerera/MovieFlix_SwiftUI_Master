using Microsoft.EntityFrameworkCore;
using MovieFlix.Api.Data;
using MovieFlix.Api.DTOs.Movies;
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

    public async Task<Movie> CreateMovieAsync(CreateMovieRequest request)
    {
        var movie = new Movie
        {
            TmdbId = request.TmdId,
            Title = request.Title,
            Overview = request.Overview
        };

        _context.Movies.Add(movie);

        await _context.SaveChangesAsync();

        return movie;
    }
}