using Microsoft.EntityFrameworkCore;
using PS.TaskPlanner.Application.Common.Interfaces.Persistence;
using PS.TaskPlanner.Domain.Entities;

namespace PS.TaskPlanner.Infrastructure.Persistence.Repositories
{
    public class WorkTaskRepository : IWorkTaskRepository
    {

        private readonly TaskPlannerDbContext _dbContext;

        public WorkTaskRepository(TaskPlannerDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        public async Task<WorkTask?> GetByIdAsync(Guid id)
        {
            return await _dbContext.WorkTasks.FirstOrDefaultAsync(w => w.Id == id);
        }

        public async Task<IEnumerable<WorkTask>> GetAllAsync()
        {
            return await _dbContext.WorkTasks.ToListAsync();
        }
        public async Task<IEnumerable<WorkTask>> GetByProjectIdAsync(Guid projectId)
        {
            return await _dbContext.WorkTasks
                .Where(task => task.ProjectId == projectId)
                .ToListAsync();
        }

        public async Task<IEnumerable<WorkTask>> GetByUserIdAsync(Guid userId)
        {
            return await _dbContext.WorkTasks
                .Where(task => task.AssignedToUserId == userId)
                .ToListAsync();
        }

        public async Task AddAsync(WorkTask entity)
        {
            await _dbContext.WorkTasks.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(WorkTask entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var workTask = new WorkTask { Id = id };
            _dbContext.WorkTasks.Attach(workTask);
            _dbContext.Entry(workTask).State = EntityState.Deleted;
            await _dbContext.SaveChangesAsync();
        }
    }
}
