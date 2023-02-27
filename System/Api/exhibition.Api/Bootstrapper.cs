using exhibition.Services.Settings;

namespace exhibition.Api
{
    public static class Bootstrapper
    {
        public static IServiceCollection RegisterAppServices(this IServiceCollection services)
        {
            services
                .AddMainSettings()

                ;

            return services;
        }
    }
}
