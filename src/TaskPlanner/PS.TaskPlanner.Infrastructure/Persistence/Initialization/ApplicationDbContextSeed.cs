using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using PS.TaskPlanner.Infrastructure.Authentication.Identity;

namespace PS.TaskPlanner.Infrastructure.Persistence.Initialization
{
    public class ApplicationDbContextSeed
    {
        public static async Task SeedAsync(IServiceProvider serviceProvider)
        {
            var logger = serviceProvider.GetRequiredService<ILogger<TaskPlannerDbContext>>();

            try
            {
                // Получаем UserManager и RoleManager
                var userManager = serviceProvider.GetRequiredService<UserManager<AuthUser>>();
                var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();

                // Создаем роли
                await EnsureRolesAsync(roleManager);

                // Создаем пользователя
                await EnsureDefaultUserAsync(userManager);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "An error occurred while seeding the database.");
            }
        }

        private static async Task EnsureRolesAsync(RoleManager<IdentityRole> roleManager)
        {
            var roles = new[] { "Admin", "User", "Manager" };

            foreach (var role in roles)
            {
                if (!await roleManager.RoleExistsAsync(role))
                {
                    await roleManager.CreateAsync(new IdentityRole(role));
                }
            }
        }

        private static async Task EnsureDefaultUserAsync(UserManager<AuthUser> userManager)
        {
            var email = "admin@example.com";
            var password = "Admin123!";
            var role = "Admin";

            if (await userManager.FindByEmailAsync(email) == null)
            {
                var user = new AuthUser { UserName = email, Email = email, EmailConfirmed = true };
                var result = await userManager.CreateAsync(user, password);

                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, role);
                }
            }
        }
    }
}
