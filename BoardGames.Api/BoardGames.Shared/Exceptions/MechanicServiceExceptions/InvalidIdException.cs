namespace BoardGames.Shared.Exceptions.MechanicServiceExceptions
{
    public class InvalidIdException : MechanicServiceException
    {
        public InvalidIdException(string message) : base(message) { }
    }
}
