using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PS.TaskPlanner.Domain.Entities;
using PS.TaskPlanner.Infrastructure.Authentication.Identity;

namespace PS.TaskPlanner.Infrastructure.Persistence
{
    public class TaskPlannerDbContext : IdentityDbContext<AuthUser>
    {
        public TaskPlannerDbContext(DbContextOptions<TaskPlannerDbContext> options) : base(options)
        {
        }

        public DbSet<AppUser> AppUsers { get; set; } = null!;
        public DbSet<Project> Projects { get; set; } = null!;
        public DbSet<WorkTask> WorkTasks { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
