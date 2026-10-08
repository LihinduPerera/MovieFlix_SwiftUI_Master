namespace MovieFlix.Api.Models
{
    public class Favorite
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int MovieId { get; set; }
        public DateTime CreatedAt { get; set; }
        public User User { get; set; } = null!;
        public Movie Movie { get; set; } = null!;
    }
}
