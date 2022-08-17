using Microsoft.Extensions.Configuration;
using Serilog.Sinks.Http;
using System.Text;

namespace BoardGames.MAUIClient
{
    internal class SerilogHttpClient : IHttpClient
    {
        private readonly HttpClient httpClient;

        public SerilogHttpClient() => httpClient = new HttpClient();

        public void Configure(IConfiguration configuration) => httpClient.DefaultRequestHeaders.Add("X-Api-Key", configuration["apiKey"]);

        public async Task<HttpResponseMessage> PostAsync(string requestUri, Stream contentStream)
        {
            using var content = new StreamContent(contentStream);
            content.Headers.Add("Content-Type", "application/json");

            var response = await httpClient
                .PostAsync(requestUri, content);

            return response;
        }

        public void Dispose() => httpClient?.Dispose();
    }
}
