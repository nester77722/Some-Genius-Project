﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGames.Shared.Exceptions
{
    public class LoginException : Exception
    {
        public LoginException(string message) : base(message) { }
    }
}
