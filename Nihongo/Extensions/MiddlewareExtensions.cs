using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Logging;

namespace Nihongo.Api.Extensions
{
    public static class MiddlewareExtensions
    {
        public static void ConfigureCustomExceptionMiddleware(this IApplicationBuilder app)
        {
            app.UseMiddleware<ExceptionMiddleware>();

            // custom jwt auth middleware
            app.UseMiddleware<JwtMiddleware>();

            app.UseCors("enableCORS");
        }
    }
}
