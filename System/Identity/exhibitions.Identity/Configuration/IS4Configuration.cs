﻿using Duende.IdentityServer.Models;
using exhibitions.Context;
using exhibitions.Context.Entities.User;
using exhibitions.Identity.Configuration.IS4;
using Microsoft.AspNetCore.Identity;

namespace exhibitions.Identity.Configuration
{
    public static class IS4Configuration
    {
        public static IServiceCollection AddIS4(this IServiceCollection services)
        {
            services
                .AddIdentity<User, UserRole>(opt =>
                {
                    opt.Password.RequiredLength = 0;
                    opt.Password.RequireDigit = false;
                    opt.Password.RequireLowercase = false;
                    opt.Password.RequireUppercase = false;
                    opt.Password.RequireNonAlphanumeric = false;
                })
                .AddEntityFrameworkStores<MainDbContext>()
                .AddUserManager<UserManager<User>>()
                .AddDefaultTokenProviders()
                ;

            services
                .AddIdentityServer()

                .AddAspNetIdentity<User>()

                .AddInMemoryApiScopes(AppApiScopes.ApiScopes)
                .AddInMemoryClients(AppClients.Clients)
                .AddInMemoryApiResources(AppResources.Resources)
                .AddInMemoryIdentityResources(AppIdentityResources.Resources)

                .AddTestUsers(AppApiTestUsers.ApiUsers)

                .AddDeveloperSigningCredential();

            return services;
        }

        public static IApplicationBuilder UseIS4(this IApplicationBuilder app)
        {
            app.UseIdentityServer();

            return app;
        }
    }
}
