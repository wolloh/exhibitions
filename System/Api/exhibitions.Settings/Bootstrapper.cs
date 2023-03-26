using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exhibitionsApi.Settings
{
    public static class Bootstrapper
    {
        public static IServiceCollection AddApiSpecialSettings(this IServiceCollection services, IConfiguration configuration = null)
        {
            var settings =exhibition.Settings.Settings.Load<ApiSpecialSettings>("ApiSpecial", configuration);
            services.AddSingleton(settings);

            return services;
        }
    }
}
