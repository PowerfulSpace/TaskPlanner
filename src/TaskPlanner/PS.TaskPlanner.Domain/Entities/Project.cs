using PS.TaskPlanner.Domain.Entities.Base;

namespace PS.TaskPlanner.Domain.Entities
{
    public class Project : BaseEntity
    {
        public string Title { get; set; } = string.Empty; // Название проекта
        public string Description { get; set; } = string.Empty; // Описание проекта
        public DateTime StartDate { get; set; } // Дата начала
        public DateTime? EndDate { get; set; } // Дата окончания
        public ICollection<WorkTask> Tasks { get; set; } = new List<WorkTask>(); // Связанные задачи
        public Guid OwnerId { get; set; } // ID владельца проекта
        public AppUser? Owner { get; set; } // Владелец проекта
    }
}
