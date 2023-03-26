using exhibition.Services.exhibitions;
using exhibition.Services.Settings;

namespace exhibition.Api
{
    public static class Bootstrapper
    {
        public static IServiceCollection RegisterAppServices(this IServiceCollection services)
        {
            services
                .AddMainSettings()
                .AddExhibitionsService()
                .AddIdentitySettings()
                .AddSwaggerSettings()
                ;

            return services;
        }
    }
}
