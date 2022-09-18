namespace BoardGames.Shared.Exceptions.GenreServiceExceptions
{
    public class InvalidIdException : GenreServiceException
    {
        public InvalidIdException(string message) : base(message) { }
    }
}
