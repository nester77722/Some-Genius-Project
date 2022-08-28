using BoardGames.MAUIClient.Models.Authentication;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGames.MAUIClient.RefitClients
{
    public interface IAuthenticationRefitClient
    {
        [Post("/Auth")]
        [QueryUriFormat(UriFormat.Unescaped)]
        Task<TokensModel> GetTokens(LoginModel loginModel);
    }
}
