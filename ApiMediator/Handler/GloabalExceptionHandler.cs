using System.Text.Json;
using ApiMediator.Response;
using Microsoft.AspNetCore.Diagnostics;

namespace ApiMediator.Handler
{
    public class GloabalExceptionHandler : IExceptionHandler
    {
        public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
        {
            httpContext.Response.StatusCode = exception switch
            {
                ArgumentException => StatusCodes.Status400BadRequest,
                InvalidOperationException => StatusCodes.Status400BadRequest,
                KeyNotFoundException => StatusCodes.Status404NotFound,
                NotImplementedException => StatusCodes.Status501NotImplemented,
                _ => StatusCodes.Status500InternalServerError
            };

            string message = exception switch
            {
                ArgumentException => "Invalid argument provided.",
                InvalidOperationException => "Invalid operation attempted.",
                NotImplementedException => "This feature is not implemented yet.",
                KeyNotFoundException => "The requested resource was not found.",
                _ => "An unexpected error occurred."
            };

            var result = new HttpResponseServerException
            {
                Status = false,
                Message = exception.Message
            };

            await httpContext.Response.WriteAsync(JsonSerializer.Serialize(result), cancellationToken);
            return true;
        }
    }
}