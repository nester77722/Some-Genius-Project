namespace BoardGames.Shared.Exceptions
{
    public class RegisterException : Exception
    {
        public RegisterException(string message) : base(message) { }

        public RegisterException(IEnumerable<string> errors)
            : this(string.Join("\r", errors))
        {
        }
    }
}
