namespace PS.TaskPlanner.Web
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPresentation(this IServiceCollection services)
        {
            services.AddControllersWithViews();

            return services;
        }
    }
}
