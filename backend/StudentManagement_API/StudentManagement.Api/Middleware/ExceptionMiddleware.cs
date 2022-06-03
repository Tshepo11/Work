using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace StudentManagement.Api.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger _logger;

        public ExceptionMiddleware(RequestDelegate next, ILoggerFactory logger)
        {
            _logger = logger.CreateLogger("Global");
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong: {ex}");
                await HandleExceptionAsync(httpContext, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            string errorMessage;

            switch (exception)
            {
                // todo: improve checks and messages from caller
                case KeyNotFoundException _:
                    context.Response.StatusCode = (int)HttpStatusCode.NotFound;
                    errorMessage = exception.Message;
                    break;
                case ArgumentException _:
                    context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                    errorMessage = exception.Message;
                    break;
                case InvalidOperationException _:
                    context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                    errorMessage = exception.Message;
                    break;
                default:
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    errorMessage = $"Internal Server Error: {exception.Message}";
                    break;
            }

            context.Response.ContentType = "application/json";

            return context.Response.WriteAsync(
                new ErrorResponse
                {
                    status = context.Response.StatusCode,
                    message = errorMessage,
                    error = new { message = errorMessage }
                }.ToString()
            );
        }
    }
}
