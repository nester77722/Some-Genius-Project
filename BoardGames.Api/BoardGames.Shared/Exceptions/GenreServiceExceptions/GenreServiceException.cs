namespace BoardGames.Shared.Exceptions.GenreServiceExceptions
{
    public class GenreServiceException : ServiceException
    {
        public GenreServiceException(string message) : base(message, "GenreService") { }
    }
}
