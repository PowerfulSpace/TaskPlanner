﻿using Microsoft.Extensions.DependencyInjection;

namespace PS.TaskPlanner.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            return services;
        }
    }
}
