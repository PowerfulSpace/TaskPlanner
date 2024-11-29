using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PS.TaskPlanner.Application.Common.Interfaces.Persistence;
using PS.TaskPlanner.Infrastructure.Authentication.Identity;
using PS.TaskPlanner.Infrastructure.Mapping;
using PS.TaskPlanner.Infrastructure.Persistence;
using PS.TaskPlanner.Infrastructure.Persistence.Repositories;

namespace PS.TaskPlanner.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, ConfigurationManager configuration)
        {
            services
               .AddPersistance(configuration);

            services.AddMapping(); // Регистрация маппинга

            services.AddScoped<IWorkTaskRepository, WorkTaskRepository>();
            services.AddScoped<IProjectRepository, ProjectRepository>();
            services.AddScoped<IAppUserRepository, AppUserRepository>();

            return services;
        }

        private static IServiceCollection AddPersistance(this IServiceCollection services, ConfigurationManager configuration)
        {
            services.AddDbContext<TaskPlannerDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            services.AddIdentity<AuthUser, IdentityRole>()
                .AddEntityFrameworkStores<TaskPlannerDbContext>()
                .AddDefaultTokenProviders();

            return services;
        }

        private static IServiceCollection AddMapping(this IServiceCollection services)
        {
            AuthenticationMappingConfig.Configure();
            return services;
        }
    }
}
