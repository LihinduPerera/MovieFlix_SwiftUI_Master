using Microsoft.EntityFrameworkCore;
using MovieFlix.Api.Data;
using MovieFlix.Api.DTOs.Movies;
using MovieFlix.Api.Exceptions;
using MovieFlix.Api.Models;

namespace MovieFlix.Api.Services;

public class MovieService : IMovieService
{
    private readonly MovieFlixDbContext _context;

    public MovieService(MovieFlixDbContext context)
    {
        _context = context;
    }

    private static MovieResponse MapToResponse(Movie movie)
    {
        return new MovieResponse
        {
            Id = movie.Id,
            TmdbId = movie.TmdbId,
            Title = movie.Title,
            Overview = movie.Overview
        };
    }

    public async Task<List<MovieResponse>> GetMoviesAsync()
    {
        var movies = await _context.Movies
            .AsNoTracking()
            .ToListAsync();

        return movies
            .Select(MapToResponse)
            .ToList();
    }

    public async Task<MovieResponse?> GetMovieByIdAsync(int id)
    {
        var movie = await _context.Movies
            .AsNoTracking()
            .FirstOrDefaultAsync(movie => movie.Id == id);

        if(movie is null)
        {
            return null;
        }

        return MapToResponse(movie);
    }

    public async Task<MovieResponse> CreateMovieAsync(CreateMovieRequest request)
    {
        var existingMovie = await _context.Movies
            .AsNoTracking()
            .FirstOrDefaultAsync(movie => movie.TmdbId == request.TmdbId);

        if(existingMovie is not null)
        {
            throw new MovieAlreadyExistsException(request.TmdbId);
        }

        var movie = new Movie
        {
            TmdbId = request.TmdbId,
            Title = request.Title,
            Overview = request.Overview
        };

        _context.Movies.Add(movie);

        await _context.SaveChangesAsync();

        return MapToResponse(movie);
    }

    public async Task<MovieResponse?> UpdateMovieAsync(int id, UpdateMovieRequest request)
    {
        var movie = await _context.Movies
            .FirstOrDefaultAsync(movie => movie.Id == id);

        if(movie is null)
        {
            return null;
        }

        movie.Title = request.Title;
        movie.Overview = request.Overview;

        await _context.SaveChangesAsync();

        return MapToResponse(movie);
    }

    public async Task<bool> DeleteMovieAsync(int id)
    {
        var movie = await _context.Movies
            .FirstOrDefaultAsync(movie => movie.Id == id);

        if(movie is null)
        {
            return false;
        }

        _context.Movies.Remove(movie);

        await _context.SaveChangesAsync();

        return true;
    }
}