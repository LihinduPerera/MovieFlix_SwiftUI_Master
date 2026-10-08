namespace MovieFlix.Api.Exceptions
{
    public class FavoriteAlreadyExistsException : Exception
    {
        public FavoriteAlreadyExistsException(int userId, int movieId)
            : base($"User {userId} has already favorited movie {movieId}.")
        {

        }
    }
}
