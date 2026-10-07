using System.ComponentModel.DataAnnotations;

namespace MovieFlix.Api.DTOs.Movies
{
    public class UpdateMovieRequest
    {
        [Required]
        [MaxLength(200)]
        public string Title { get; set; } = string.Empty;

        [Required]
        [MaxLength(2000)]
        public string Overview { get; set; } = string.Empty;
    }
}
