using Microsoft.Extensions.Options;

namespace exhibition.Api.Configuration
{
    public static class ControllerConfiguration
    {
        public static IServiceCollection AddAppController(this IServiceCollection services)
        {

            services
            .AddControllers()
                ;

            return services;
        }
        public static IEndpointRouteBuilder UseAppController(this IEndpointRouteBuilder app)
        {
            app.MapControllers();

            return app;
        }
    }
}
