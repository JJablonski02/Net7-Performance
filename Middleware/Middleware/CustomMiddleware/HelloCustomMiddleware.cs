using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace testexamples.CustomMiddleware
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class HelloCustomMiddleware
    {
        private readonly RequestDelegate _next;

        public HelloCustomMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            if (httpContext.Request.Query.ContainsKey
                ("firstName") &&
                httpContext.Request.Query.ContainsKey
                ("lastName"))
            {
                string fullname = httpContext.Request.Query["firstName"] + " " +
                     httpContext.Request.Query["lastName"];
                await httpContext.Response.WriteAsync(fullname);
            }
            await _next(httpContext);
            //after logic
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class HelloCustomMiddlewareExtensions
    {
        public static IApplicationBuilder UseHelloCustomMiddleware
            (this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<HelloCustomMiddleware>();
        }
    }
}
