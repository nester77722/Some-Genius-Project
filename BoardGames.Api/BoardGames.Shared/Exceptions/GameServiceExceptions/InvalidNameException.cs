namespace BoardGames.Shared.Exceptions.GameServiceExceptions
{
    public class InvalidNameException : GameServiceException
    {
        public InvalidNameException(string message) : base(message) { }
    }
}
