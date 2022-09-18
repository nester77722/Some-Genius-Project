namespace BoardGames.Shared.Exceptions.GameServiceExceptions
{
    public class GameServiceException : ServiceException
    {
        public GameServiceException(string message) : base(message, "GameService") { }
    }
}
