namespace BoardGames.Shared.Exceptions.GenreServiceExceptions
{
    public class InvalidNameException : GenreServiceException
    {
        public InvalidNameException(string message) : base(message) { }

    }
}
