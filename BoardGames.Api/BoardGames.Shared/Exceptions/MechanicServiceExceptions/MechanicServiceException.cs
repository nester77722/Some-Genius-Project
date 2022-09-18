namespace BoardGames.Shared.Exceptions.MechanicServiceExceptions
{
    public class MechanicServiceException : ServiceException
    {
        public MechanicServiceException(string message) : base(message, "MechanicService") { }
    }
}
