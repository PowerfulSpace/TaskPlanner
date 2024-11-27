using PS.TaskPlanner.Domain.Entities.Base;
using PS.TaskPlanner.Domain.Enums;

namespace PS.TaskPlanner.Domain.Entities
{
    public class WorkTask : BaseEntity
    {
        public string Title { get; set; } = string.Empty; // Название задачи
        public string Description { get; set; } = string.Empty; // Описание задачи
        public WorkTaskStatus Status { get; set; } // Статус задачи
        public WorkTaskPriority Priority { get; set; } // Приоритет задачи
        public DateTime? DueDate { get; set; } // Крайний срок выполнения
        public Guid? AssignedToUserId { get; set; } // ID назначенного пользователя
        public Guid ProjectId { get; set; } // ID связанного проекта
    }
}
