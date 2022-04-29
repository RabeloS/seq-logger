using Newtonsoft.Json;
using System.Net;

namespace Loggy.ServicesCollections
{
    public class ExceptionHandlerError : IMiddleware
    {

        private readonly ILogger _logger;

        public ExceptionHandlerError(ILogger<ExceptionHandlerError> logger)
        {
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {

            try
            {
                await next(context);
            }
            catch (Exception e)
            {
                _logger.LogError($" Error  -> {e.Message}");
            }
        }

        public static Task ExceptionHandlerAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            var json = new
            {
                context.Response.StatusCode,
                Message = "An error occurred whilst processing your request",
                Detailed = exception
            };

            return context.Response.WriteAsync(JsonConvert.SerializeObject(json));



        }
    }
}
