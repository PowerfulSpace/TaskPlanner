using PS.TaskPlanner.Domain.Entities.Base;

namespace PS.TaskPlanner.Domain.Entities
{
    public class AppUser : BaseEntity
    {
        public string UserName { get; set; } = string.Empty; // Имя пользователя
        public string Email { get; set; } = string.Empty;   // Email
        public bool IsActive { get; set; }
        public ICollection<WorkTask> Tasks { get; set; } = new List<WorkTask>(); // Связанные задачи
        public ICollection<Project> Projects { get; set; } = new List<Project>(); // Связанные проекты
    }
}