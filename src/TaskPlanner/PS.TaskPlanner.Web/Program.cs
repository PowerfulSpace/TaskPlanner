using Microsoft.AspNetCore.Identity;
using PS.TaskPlanner.Application;
using PS.TaskPlanner.Infrastructure;
using PS.TaskPlanner.Infrastructure.Authentication.Identity;
using PS.TaskPlanner.Infrastructure.Persistence.Initialization;
using PS.TaskPlanner.Web;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services
        .AddPresentation()
        .AddApplication()
        .AddInfrastructure(builder.Configuration);

    builder.Services.AddRazorPages();
}

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    try
    {
        var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();
        var userManager = services.GetRequiredService<UserManager<AuthUser>>();

        // Проверка, существуют ли роли или пользователи
        if (!await roleManager.RoleExistsAsync("Admin") ||
            await userManager.FindByEmailAsync("admin@example.com") == null)
        {
            await ApplicationDbContextSeed.SeedAsync(services);
        }
    }
    catch (Exception ex)
    {
        var logger = services.GetRequiredService<ILogger<Program>>();
        logger.LogError(ex, "An error occurred while seeding the database.");
    }
}


app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapRazorPages();

app.Run();
