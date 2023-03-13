using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exhibition.Services.exhibitions
{
    public static class Bootstrapper
    {
        public static IServiceCollection AddExhibitionsService(this IServiceCollection services)
        {
            services.AddSingleton<IExhibitionService, ExhibitionService>();

            return services;
        }
    }
}
