using PS.TaskPlanner.Application.Dtos.WorkTasks;

namespace PS.TaskPlanner.Application.Dtos.Projects
{
    public class ProjectDto
    {
        public Guid Id { get; set; } // ID проекта
        public string Title { get; set; } = string.Empty; // Название проекта
        public string Description { get; set; } = string.Empty; // Описание проекта
        public DateTime StartDate { get; set; } // Дата начала
        public DateTime? EndDate { get; set; } // Дата окончания
        public Guid OwnerId { get; set; } // ID владельца проекта
        public string OwnerName { get; set; } = string.Empty; // Имя владельца проекта
        public List<WorkTaskDto> Tasks { get; set; } = new(); // Связанные задачи
    }
}
