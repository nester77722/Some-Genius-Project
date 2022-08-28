using BoardGames.Shared.Exceptions.GameServiceExceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGames.Shared.Exceptions.GenreServiceExceptions
{
    public class InvalidIdException : GenreServiceException
    {
        public InvalidIdException(string message) : base(message) { }
    }
}
