using CarsAPI.Exceptions;
using Microsoft.AspNetCore.Http;

namespace CarsAPI.Middleware
{
    public class ErrorHandlingMiddleware : IMiddleware
    {
        private readonly ILogger<ErrorHandlingMiddleware> _logger;
        public ErrorHandlingMiddleware(ILogger<ErrorHandlingMiddleware> logger)
        {
            _logger = logger;
        }
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next.Invoke(context);
            }
            catch (BadRequestException badRequestException)
            {
                var data = new { message = badRequestException.Message };

                context.Response.StatusCode = 400;
                await context.Response.WriteAsJsonAsync(data);
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                var data = new { message = ex.Message };

                context.Response.StatusCode = 500;
                await context.Response.WriteAsJsonAsync(data);
            }
        }
    }
}
