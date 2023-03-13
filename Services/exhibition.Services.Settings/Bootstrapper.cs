using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using exhibition.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using exhibiton.Services.Settings;

namespace exhibition.Services.Settings
{
    public static class Bootstrapper
    {

        public static IServiceCollection AddIdentitySettings(this IServiceCollection services, IConfiguration configuration = null)
        {
            var settings = exhibition.Settings.Settings.Load<IdentitySettings>("Identity", configuration);
            services.AddSingleton(settings);

            return services;
        }

        public static IServiceCollection AddMainSettings(this IServiceCollection services, IConfiguration configuration = null)
        {
            var settings = exhibition.Settings.Settings.Load<MainSettings>("Main", configuration);
            services.AddSingleton(settings);

            return services;
        }
        public static IServiceCollection AddSwaggerSettings(this IServiceCollection services, IConfiguration configuration = null)
        {
            var settings = exhibition.Settings.Settings.Load<SwaggerSettings>("Swagger", configuration);
            services.AddSingleton(settings);

            return services;
        }

    }
}
