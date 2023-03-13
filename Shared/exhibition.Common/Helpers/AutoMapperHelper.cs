using Microsoft.Extensions.DependencyInjection;

namespace exhibition.Common.Helpers
{
    public static class AutoMappersRegisterHelper
    {
        public static void Register(IServiceCollection services)
        {
            var assemblies = AppDomain.CurrentDomain.GetAssemblies()
                .Where(s => s.FullName != null && (s.FullName.ToLower().StartsWith("testsolution.") ||  s.FullName.ToLower().StartsWith("mainapi")));

            services.AddAutoMapper(assemblies);
        }
    }
}
