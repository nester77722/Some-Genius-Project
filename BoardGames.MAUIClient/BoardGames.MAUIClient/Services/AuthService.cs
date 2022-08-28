using BoardGames.MAUIClient.Models.Authentication;
using BoardGames.MAUIClient.RefitClients;
using BoardGames.MAUIClient.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGames.MAUIClient.Services
{
    public class AuthService : IAuthService
    {
        private readonly IAuthenticationRefitClient _refitClient;

        public AuthService(IAuthenticationRefitClient refitClient)
        {
            _refitClient = refitClient;
        }

        public TokensModel Tokens
        {
            get
            {
                var accessToken = Preferences.Get("AccessToken", string.Empty);
                var refreshToken = Preferences.Get("RefreshToken", string.Empty);

                return new TokensModel { AccessToken = accessToken, RefreshToken = refreshToken };

            }

            private set
            {
                Preferences.Set("AccessToken", value.AccessToken);
                Preferences.Set("RefreshToken", value.RefreshToken);
            }
        }

        public bool TokensAvailable
        {
            get
            {
                var accessToken = Preferences.Get("AccessToken", string.Empty);
                var refreshToken = Preferences.Get("RefreshToken", string.Empty);

                return string.IsNullOrEmpty(accessToken) && string.IsNullOrEmpty(refreshToken);
            }
        }

        public async Task<TokensModel> GetTokens(LoginModel loginModel)
        {
            var tokens = await _refitClient.GetTokens(loginModel);

            return tokens;
        }
    }
}
