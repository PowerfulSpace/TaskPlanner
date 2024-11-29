using PS.TaskPlanner.Application.Common.Interfaces.Persistence.Base;
using PS.TaskPlanner.Domain.Entities;

namespace PS.TaskPlanner.Application.Common.Interfaces.Persistence
{
    public interface IProjectRepository : ICrudRepository<Project>
    {
        Task<IEnumerable<Project>> GetByUserIdAsync(Guid userId);
    }
}
