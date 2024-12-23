﻿using Mapster;
using MapsterMapper;

namespace PS.TaskPlanner.Web
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPresentation(this IServiceCollection services)
        {
            services.AddControllersWithViews();

            services
                .AddMapsterConfiguration()
                .AddAuthorizationPolicies();

            return services;
        }

        private static IServiceCollection AddMapsterConfiguration(this IServiceCollection services)
        {
            var config = TypeAdapterConfig.GlobalSettings;
            config.Scan(typeof(DependencyInjection).Assembly); // Сканируем текущую сборку для маппинга
            services.AddSingleton(config);
            services.AddScoped<IMapper, ServiceMapper>();

            return services;
        }

        private static IServiceCollection AddAuthorizationPolicies(this IServiceCollection services)
        {
            services.AddAuthorization(options =>
            {
                options.AddPolicy("AdminPolicy", policy =>
                    policy.RequireRole("Admin"));


                options.AddPolicy("ManagerPolicy", policy =>
                {
                    policy.RequireAssertion(context =>
                        context.User.IsInRole("Admin")
                        || context.User.IsInRole("Manager"));
                });


                options.AddPolicy("UserPolicy", policy =>
                {
                    policy.RequireAssertion(context =>
                        context.User.IsInRole("Admin")
                        || context.User.IsInRole("Manager")
                        || context.User.IsInRole("User"));
                });
            });

            return services;
        }
    }
}
