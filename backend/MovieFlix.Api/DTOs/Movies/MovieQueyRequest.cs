namespace MovieFlix.Api.DTOs.Movies
{
    public class MovieQueyRequest
    {
        public int Page { get; set; } = 1;

        public int PageSize { get; set; } = 20;

        public string? Search { get; set; }

        public string SortBy { get; set; } = "id";

        public string SortOrder { get; set; } = "asc";
    }
}
