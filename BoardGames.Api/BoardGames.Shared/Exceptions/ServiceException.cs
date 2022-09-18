namespace BoardGames.Shared.Exceptions
{
    public class ServiceException : Exception
    {
        public string ServiceName { get; init; } = string.Empty;
        public ServiceException(string message, string serviceName)
            : base(message)
        {
            ServiceName = serviceName;
        }

    }
}
