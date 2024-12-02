namespace PS.TaskPlanner.Web.Models
{
    public class ProjectViewModel
    {
        public Guid Id { get; set; } // ID проекта
        public string Title { get; set; } = string.Empty; // Название проекта
        public string Description { get; set; } = string.Empty; // Описание проекта
        public DateTime StartDate { get; set; } // Дата начала
        public DateTime? EndDate { get; set; } // Дата окончания
        public Guid OwnerId { get; set; } // ID владельца проекта
        public string OwnerName { get; set; } = string.Empty; // Имя владельца проекта
        public List<WorkTaskViewModel> Tasks { get; set; } = new(); // Связанные задачи
    }
}
