using System.Text.Json.Serialization;

namespace MovieFlix.Api.DTOs.Tmdb
{
    public class TmdbMovieDetailsResponse
    {
        public int Id { get; set; }

        public string Title { get; set; } = string.Empty;

        public string Overview { get; set; } = string.Empty;

        [JsonPropertyName("poster_path")]
        public string? PosterPath { get; set; }

        [JsonPropertyName("backdrop_path")]
        public string? BackdropPath { get; set; }

        [JsonPropertyName("release_date")]
        public string ReleaseDate { get; set; } = string.Empty;

        [JsonPropertyName("vote_average")]
        public double VoteAverage { get; set; }

        [JsonPropertyName("vote_count")]
        public int VoteCount { get; set; }

        public int? Runtime { get; set; }

        public string? Tagline { get; set; }

        public List<TmdbGenre> Genres { get; set; } = [];
    }
    public class TmdbGenre
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;
    }
}