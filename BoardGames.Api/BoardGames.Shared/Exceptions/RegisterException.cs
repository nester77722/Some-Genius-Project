using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
