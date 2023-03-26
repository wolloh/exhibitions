﻿using Api.Middlewares;

namespace Api.Configuration
{
    public static class MiddlewaresConfiguration
    {
        public static void UseAppMiddlewares(this IApplicationBuilder app)
        {
            app.UseMiddleware<ExceptionsMiddleware>();
        }
    }
}
