using CAT.Application.Exceptions;
using CAT.Domain.Primitives;
using System.Net;
using System.Net.Mail;
using System.Runtime.CompilerServices;
using System.Text.Json;

namespace CAT.Presentation.Middleware
{
    internal class CustomExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<CustomExceptionHandlerMiddleware> _logger;

        public CustomExceptionHandlerMiddleware(RequestDelegate next, ILogger<CustomExceptionHandlerMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception occurred: {Message}", ex.Message);

                await HandleExceptionAsync(httpContext, ex);
            }
        }

        private static async Task HandleExceptionAsync(HttpContext httpContext, Exception exception)
        {
            httpContext.Response.ContentType = "application/json";

            //int statusCode = exception.GetType();

            //int statusCode = this.SetStatusCode(exception.GetType());

            httpContext.Response.StatusCode = (int)401;

            var serializerOptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };

            string response = JsonSerializer.Serialize(new Exception("LOL").Message, serializerOptions);

            await httpContext.Response.WriteAsync(response);
        }

        //private static SetStatusCode(Type type)
        //{
        //    switch (type)
        //    {

        //    }
        //}
    }
}
