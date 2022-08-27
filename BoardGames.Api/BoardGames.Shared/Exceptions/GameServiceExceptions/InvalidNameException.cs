using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGames.Shared.Exceptions.GameServiceExceptions
{
    public class InvalidNameException : GameServiceException
    {
        public InvalidNameException(string message) : base(message) { }
    }
}
