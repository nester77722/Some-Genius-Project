using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGames.Shared.Exceptions.GameServiceExceptions
{
    public class GameServiceException : ServiceException
    {
        public GameServiceException(string message) : base(message, "GameService") { }
    }
}
