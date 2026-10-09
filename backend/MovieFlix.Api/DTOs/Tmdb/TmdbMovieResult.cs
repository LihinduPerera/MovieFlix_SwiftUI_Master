namespace MovieFlix.Api.DTOs.Tmdb
{
    public class TmdbMovieResult
    {
        public int Id { get; set; }

        public string Title { get; set; } = string.Empty;

        public string Overview { get; set; } = string.Empty;

        public string? PosterPath { get; set; }

        public string? BackdropPath { get; set; }

        public string ReleaseDate { get; set; } = string.Empty;

        public double VoteAverage { get; set; }

        public int VoteCount { get; set; }
    }
}
