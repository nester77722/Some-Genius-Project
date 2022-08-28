using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGames.Shared.Exceptions.GenreServiceExceptions
{
    public class GenreServiceException : ServiceException
    {
        public GenreServiceException(string message) : base(message, "GenreService") { }
    }
}
