using System.Net;
using System.Text.Json;
using DDDWebApi.CrossCutting.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Builder;

namespace DDDWebApi.Middleware
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionHandlingMiddleware> _logger;

        public ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Unhandled exception");
                await HandleExceptionAsync(httpContext, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            var response = DDDWebApi.CrossCutting.Responses.ApiResponse<string>.FailResponse(new[] { exception.Message }, "An unexpected error occurred", (int)HttpStatusCode.InternalServerError);
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = response.StatusCode;
            var json = JsonSerializer.Serialize(response);
            return context.Response.WriteAsync(json);
        }
    }

    public static class ExceptionHandlingMiddlewareExtensions
    {
        public static IApplicationBuilder UseExceptionHandling(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ExceptionHandlingMiddleware>();
        }
    }
}