namespace MovieFlix.Api.DTOs.Movies
{
    public class MovieSearchPageResponse
    {
        public int Page { get; set; }

        public List<MovieSearchResponse> Results { get; set; } = [];

        public int TotalPages { get; set; }

        public int TotalResults { get; set; }
    }
}
