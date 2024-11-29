using PS.TaskPlanner.Domain.Entities;

namespace PS.TaskPlanner.Application.Common.Interfaces.Persistence
{
    public interface IAppUserRepository
    {
        Task<AppUser?> GetByIdAsync(Guid id);
        Task<AppUser?> GetByEmailAsync(string email);
        Task<IEnumerable<AppUser>> GetAllAsync();
        Task UpdateAsync(AppUser user);
    }
}
