using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGames.Shared.Exceptions
{
    public class ServiceException : Exception
    {
        public ServiceException(string message, string serviceName) : base($"Error in {serviceName}. Error message: {message}") { }
    }
}
