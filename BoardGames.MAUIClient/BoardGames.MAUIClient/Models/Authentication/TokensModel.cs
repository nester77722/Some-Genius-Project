using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGames.MAUIClient.Models.Authentication
{
    public class TokensModel
    {
        public string AccessToken { get; set; }

        public string RefreshToken { get; set; }
    }
}
