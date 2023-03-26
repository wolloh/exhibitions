﻿using Microsoft.AspNetCore.Mvc;

namespace Api.Configuration
{
    public static class VersioningConfiguration
    {
        /// <summary>
        /// Add version support for API
        /// </summary>
        /// <param name="services">Services collection</param>
        public static IServiceCollection AddAppVersioning(this IServiceCollection services)
        {
            services.AddApiVersioning(options =>
            {
                options.ReportApiVersions = true;

                options.AssumeDefaultVersionWhenUnspecified = true;
                options.DefaultApiVersion = new ApiVersion(1, 0);
            });

            services.AddVersionedApiExplorer(options =>
            {
                options.GroupNameFormat = "'v'VVV";
                options.SubstituteApiVersionInUrl = true;
            });

            return services;
        }
    }
}
