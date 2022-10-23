using CleanArchitectureSample.Shared.Abstractions.Exceptions;
using Microsoft.AspNetCore.Http;
using System.Text.Json;

namespace CleanArchitectureSample.Shared.Exceptions
{
    internal sealed class ExceptionMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next.Invoke(context);
            }
            catch(AppException ex)
            {
                context.Response.StatusCode = 400;
                context.Response.Headers.Add("content-type", "application/json");

                var errorCode = ex.GetType().Name.Replace("Exception", string.Empty);
                var json = JsonSerializer.Serialize(new { ErrorCode = errorCode, ex.Message });
                await context.Response.WriteAsync(json);
            }
        }
    }
}
