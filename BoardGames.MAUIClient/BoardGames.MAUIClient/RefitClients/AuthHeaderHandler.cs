using BoardGames.MAUIClient.Services.Interfaces;
using System.Net.Http.Headers;

namespace BoardGames.MAUIClient.RefitClients
{
    public class AuthHeaderHandler : DelegatingHandler
    {
        private readonly IAuthService _authService;

        public AuthHeaderHandler(IAuthService authService)
        {
            _authService = authService;
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            //var token = _authService.Tokens.AccessToken;

            //request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);

            return await base.SendAsync(request, cancellationToken).ConfigureAwait(false);
        }
    }
}
