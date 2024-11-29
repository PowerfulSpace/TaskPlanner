using Microsoft.EntityFrameworkCore;
using PS.TaskPlanner.Application.Common.Interfaces.Persistence;
using PS.TaskPlanner.Domain.Entities;

namespace PS.TaskPlanner.Infrastructure.Persistence.Repositories
{
    public class ProjectRepository : IProjectRepository
    {

        private readonly TaskPlannerDbContext _dbContext;

        public ProjectRepository(TaskPlannerDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Project?> GetByIdAsync(Guid id)
        {
            return await _dbContext.Projects
                .Include(p => p.Tasks) // Если нужно загрузить связанные задачи.
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IEnumerable<Project>> GetAllAsync()
        {
            return await _dbContext.Projects.ToListAsync();
        }
        public async Task<IEnumerable<Project>> GetByUserIdAsync(Guid userId)
        {
            return await _dbContext.Projects
                .Where(p => p.OwnerId == userId)
                .ToListAsync();
        }

        public async Task AddAsync(Project entity)
        {
            await _dbContext.Projects.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(Project entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var project = new Project { Id = id };
            _dbContext.Projects.Attach(project);
            _dbContext.Entry(project).State = EntityState.Deleted;
            await _dbContext.SaveChangesAsync();
        }
    }
}
