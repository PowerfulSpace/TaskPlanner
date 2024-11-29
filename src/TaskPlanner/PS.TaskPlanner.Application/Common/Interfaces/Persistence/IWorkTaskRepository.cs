using PS.TaskPlanner.Application.Common.Interfaces.Persistence.Base;
using PS.TaskPlanner.Domain.Entities;

namespace PS.TaskPlanner.Application.Common.Interfaces.Persistence
{
    public interface IWorkTaskRepository : ICrudRepository<WorkTask>
    {
        Task<IEnumerable<WorkTask>> GetByProjectIdAsync(Guid projectId);
        Task<IEnumerable<WorkTask>> GetByUserIdAsync(Guid userId);
    }
}
