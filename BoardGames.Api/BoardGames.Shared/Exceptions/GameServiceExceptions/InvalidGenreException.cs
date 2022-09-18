namespace BoardGames.Shared.Exceptions.GameServiceExceptions
{
    public class InvalidGenreException : GameServiceException
    {
        public InvalidGenreException(string message) : base(message) { }

    }
}
