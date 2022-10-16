using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using System.Threading.Tasks;
using UML;

namespace WebApi.Middleware
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class UMLMiddleware
    {
        private readonly RequestDelegate _next;

        private readonly SsoUser UML;
        public UMLMiddleware(RequestDelegate next, IOptions<SsoUser.Uconfig> config)
        {
            _next = next;
            UML = new SsoUser(config.Value);
        }

        public async Task Invoke(HttpContext httpContext)
        {
            if (!UML.Authorize(httpContext))
            {
                //httpContext.Response.Redirect(UML.generateLoginRedirect(httpContext.Request.Host.Value, httpContext.Request.Path), true);
                httpContext.Response.StatusCode = StatusCodes.Status401Unauthorized;
                return;
            }



            await _next(httpContext);


        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class UMLMiddlewareExtensions
    {
        public static IApplicationBuilder UseUMLMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<UMLMiddleware>();
        }
    }
}
