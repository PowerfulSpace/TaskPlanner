using Microsoft.EntityFrameworkCore;
using PS.TaskPlanner.Application.Common.Interfaces.Persistence;
using PS.TaskPlanner.Domain.Entities;

namespace PS.TaskPlanner.Infrastructure.Persistence.Repositories
{
    public class AppUserRepository : IAppUserRepository
    {
        private readonly TaskPlannerDbContext _dbContext;

        public AppUserRepository(TaskPlannerDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<AppUser?> GetByIdAsync(Guid id)
        {
            return await _dbContext.AppUsers
                .FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task<AppUser?> GetByEmailAsync(string email)
        {
            return await _dbContext.AppUsers
                .FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task<IEnumerable<AppUser>> GetAllAsync()
        {
            return await _dbContext.AppUsers.ToListAsync();
        }

        public async Task AddAsync(AppUser entity)
        {
            await _dbContext.AppUsers.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(AppUser entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var user = new AppUser { Id = id };
            _dbContext.AppUsers.Attach(user);
            _dbContext.Entry(user).State = EntityState.Deleted;
            await _dbContext.SaveChangesAsync();
        }
    }
}
