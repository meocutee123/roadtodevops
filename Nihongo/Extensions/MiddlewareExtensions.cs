using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Logging;
using Nihongo.Api.Extensions.CustomExceptionMiddleware;

namespace Nihongo.Api.Extensions
{
    public static class MiddlewareExtensions
    {
        public static void ConfigureCustomExceptionMiddleware(this IApplicationBuilder app)
        {
            app.UseMiddleware<ExceptionMiddleware>();
        }
    }
}
