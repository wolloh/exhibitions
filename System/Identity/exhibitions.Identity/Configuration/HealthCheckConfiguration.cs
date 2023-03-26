﻿using exhibition.Common.HealthChecks;
using exhibitions.Identity.Configuration.HealthChecks;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;

namespace exhibitions.Identity.Configuration
{
    public static class HealthCheckConfiguration
    {
        public static IServiceCollection AddAppHealthChecks(this IServiceCollection services)
        {
            services.AddHealthChecks()
                .AddCheck<SelfHealthCheck>("DSRNetSchool.Identity");

            return services;
        }

        public static void UseAppHealthChecks(this WebApplication app)
        {
            app.MapHealthChecks("/health");

            app.MapHealthChecks("/health/detail", new HealthCheckOptions
            {
                ResponseWriter = HealthCheckHelper.WriteHealthCheckResponse,
                AllowCachingResponses = false,
            });
        }
    }
}
