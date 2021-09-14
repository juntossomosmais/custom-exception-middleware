using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;

namespace JSM.CustomExceptionMiddleware
{
    public static class CustomExceptionMiddlewareExtensions
    {
        public static IApplicationBuilder UseCustomExceptionMiddleware(this IApplicationBuilder app)
        {
            return app.UseMiddleware<CustomExceptionMiddleware>();
        }

        public static IApplicationBuilder UseCustomExceptionMiddleware(
            this IApplicationBuilder app,
            CustomExceptionOptions options)
        {
            return app.UseMiddleware<CustomExceptionMiddleware>(Options.Create(options));
        }

        public static IApplicationBuilder UseCustomExceptionMiddleware(
            this IApplicationBuilder app,
            Action<CustomExceptionOptions> configureOptions)
        {
            CustomExceptionOptions options;
            using (var scope = app.ApplicationServices.CreateScope())
            {
                options = scope.ServiceProvider.GetRequiredService<IOptionsSnapshot<CustomExceptionOptions>>().Value;
                configureOptions.Invoke(options);
            }

            return app.UseMiddleware<CustomExceptionMiddleware>(Options.Create(options));
        }
    }
}