using BoardGames.MAUIClient.Models.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGames.MAUIClient.Services.Interfaces
{
    public interface IAuthService
    {
        public TokensModel Tokens { get; }
        public Task<TokensModel> GetTokens(LoginModel loginModel);
        public bool TokensAvailable { get; }

    }
}
