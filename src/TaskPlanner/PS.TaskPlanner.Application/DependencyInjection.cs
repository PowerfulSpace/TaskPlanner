using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using PS.TaskPlanner.Application.Behaviors;
using System.Reflection;

namespace PS.TaskPlanner.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services
                .AddMediatRConfiguration()
                .AddValidationConfiguration();

            return services;
        }

        private static IServiceCollection AddMediatRConfiguration(this IServiceCollection services)
        {
            services.AddMediatR(x => x.RegisterServicesFromAssembly(typeof(DependencyInjection).Assembly));
            return services;
        }

        private static IServiceCollection AddValidationConfiguration(this IServiceCollection services)
        {
            services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            return services;
        }
    }
}
