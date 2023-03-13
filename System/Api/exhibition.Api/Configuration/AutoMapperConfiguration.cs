﻿using exhibition.Common.Helpers;

namespace Api.Configuration
{
    public static class AutoMapperConfiguration
    {
        /// <summary>
        /// Add automappers
        /// </summary>
        /// <param name="services">Services collection</param>
        public static IServiceCollection AddAppAutoMappers(this IServiceCollection services)
        {
            AutoMappersRegisterHelper.Register(services);

            return services;
        }
    }
}
