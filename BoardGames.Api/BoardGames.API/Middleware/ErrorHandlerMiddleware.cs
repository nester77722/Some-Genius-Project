using BoardGames.Shared.Exceptions;
using Serilog;
using System.Net;
using System.Text.Json;

namespace BoardGames.API.Middleware
{
    public class ErrorHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public ErrorHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception error)
            {
                var response = context.Response;
                response.ContentType = "application/json";

                switch (error)
                {
                    case ServiceException e:
                        response.StatusCode = (int)HttpStatusCode.BadRequest;
                        break;
                    case RegisterException e:
                        response.StatusCode = (int)HttpStatusCode.BadRequest;
                        break;
                    case LoginException e:
                        response.StatusCode = (int)(HttpStatusCode.Unauthorized);
                        break;
                    default:
                        response.StatusCode = (int)HttpStatusCode.InternalServerError;
                        break;
                }

                var result = JsonSerializer.Serialize(new
                {
                    message = error?.Message,
                    serviceName = (error as ServiceException)?.ServiceName
                });
                Log.Error(DateTime.Now + ": " + error?.Message);
                await response.WriteAsync(result);
            }
        }
    }
}
